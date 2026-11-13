using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Helpers;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsAsync(ProductQueryParameters query)
        {
            var products = _context.Products.AsQueryable();

            // Filtering
            if (!string.IsNullOrEmpty(query.Category))
                products = products.Where(p => p.Category.Name == query.Category);

            // Sorting
            if(!string.IsNullOrEmpty(query.SortBy))
            {
                switch(query.SortBy.ToLower())
                {
                    case "price": products = products.OrderBy(p => p.Price); break;
                    case "name": products = products.OrderBy(p => p.Name); break;
                    default : products = products.OrderBy(p => p.Product_Id); break;
                }
            }

            // Pagination
            products = products
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);

            return await products.ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var currentProduct = await _context.Products.FindAsync(product.Product_Id);

            if (currentProduct == null)
                return false;

            _context.Products.Entry(currentProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
