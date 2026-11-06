using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<ProductImage> GetProductImageAsync(int id);
        Task<List<ProductImage>> GetProductImagesAsync();
        Task<ProductImage> AddProductImageAsync(ProductImage productImage);
        Task<bool> UpdateProductImageAsync(ProductImage productImage);
        Task<bool> DeleteProductImageAsync(int id);
    }
}
