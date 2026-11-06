using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _repository;

        public ProductImageService(IProductImageRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductImage> AddProductImageAsync(ProductImage productImage)
        {
            return await _repository.AddProductImageAsync(productImage);
        }

        public async Task<bool> DeleteProductImageAsync(int id)
        {
            return await _repository.DeleteProductImageAsync(id);
        }

        public async Task<ProductImage> GetProductImageAsync(int id)
        {
            return await _repository.GetProductImageAsync(id);
        }

        public async Task<List<ProductImage>> GetProductImagesAsync()
        {
            return await _repository.GetProductImagesAsync();
        }

        public async Task<bool> UpdateProductImageAsync(ProductImage productImage)
        {
            return await _repository.UpdateProductImageAsync(productImage);
        }
    }
}
