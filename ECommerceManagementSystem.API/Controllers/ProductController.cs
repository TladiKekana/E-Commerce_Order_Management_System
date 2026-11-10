using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Application.DTOs.ProductDTOs;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly DataContext _context;

        public ProductController(IProductService productService, DataContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpGet] // GET: api/products
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();

            if(products == null)
                return NotFound();

            return Ok(products.ToResponseDto());
        }

        [HttpGet("{id}")] // GET: api/products/1
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product.ToResponseDto());
        }

        [HttpPost] // POST: api/products
        public async Task<IActionResult> AddProduct(AddProductRequestDto product)
        {
            bool categoryExists = await _context.Categories.AnyAsync(c => c.Category_Id == product.Category_Id);

            if (!categoryExists)
                return BadRequest(new { message = $"Category with Id: {product.Category_Id} does not exist" });

            bool supplierExists = await _context.Suppliers.AnyAsync(s => s.Supplier_Id == product.Supplier_Id);

            if (!supplierExists) 
                return BadRequest(new { message = $"Supplier with Id: {product.Supplier_Id} does not exist" });

            var newProduct = await _productService.AddProductAsync(product.ToEntity());

            return CreatedAtAction(nameof(GetProduct), new {id = newProduct.Product_Id}, newProduct.ToResponseDto());
        }

        [HttpDelete("{id}")] // DELETE: api/products/1
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productedDeleted = await _productService.DeleteProductAsync(id);

            if (!productedDeleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequestDto product)
        {
            if (id != product.Product_Id)
                return BadRequest();

            bool categoryExists = await _context.Categories.AnyAsync(c => c.Category_Id == product.Category_Id);

            if (!categoryExists)
                return BadRequest(new { message = $"Category with Id: {product.Category_Id} does not exist" });

            bool supplierExists = await _context.Suppliers.AnyAsync(s => s.Supplier_Id == product.Supplier_Id);

            if (!supplierExists)
                return BadRequest(new { message = $"Supplier with Id: {product.Supplier_Id} does not exist" });

            var updated = await _productService.UpdateProductAsync(product.ToEntity());

            if(!updated)
                return NotFound();

            return NoContent();
        }
    }
}
