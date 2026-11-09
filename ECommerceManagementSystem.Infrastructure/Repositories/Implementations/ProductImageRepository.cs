using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly DataContext _context;

        public ProductImageRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ProductImage> AddProductImageAsync(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();

            return productImage;
        }

        public async Task<bool> DeleteProductImageAsync(int id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);

            if(productImage == null)
                return false;

            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ProductImage> GetProductImageAsync(int id)
        {
            return await _context.ProductImages.FindAsync(id);
        }

        public async Task<List<ProductImage>> GetProductImagesAsync()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<bool> UpdateProductImageAsync(ProductImage productImage)
        {
            var currentProductImage = await _context.ProductImages.FindAsync(productImage.Image_Id);

            if (currentProductImage == null)
                return false;

            _context.ProductImages.Entry(currentProductImage).CurrentValues.SetValues(productImage);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
