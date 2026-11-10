using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet] // GET: api/products
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();

            if(products == null)
                return NotFound();

            return Ok(products);
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
        public async Task<IActionResult> AddProduct(Product product)
        {
            var newProduct = await _productService.AddProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new {id = newProduct.Product_Id}, newProduct);
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
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Product_Id)
                return BadRequest();

            var updated = await _productService.UpdateProductAsync(product);

            if(!updated)
                return NotFound();

            return NoContent();
        }
    }
}
