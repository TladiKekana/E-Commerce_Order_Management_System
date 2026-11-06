using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IProductImageRepository
    {
        Task<ProductImage> GetProductImageAsync(int id);
        Task<List<ProductImage>> GetProductImagesAsync();
        Task<ProductImage> AddProductImageAsync(ProductImage productImage);
        Task<bool> UpdateProductImageAsync(ProductImage productImage);
        Task<bool> DeleteProductImageAsync(int id);
    }
}
