using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IProductSupplierService
    {
        Task<ProductSupplier> GetProductSupplierAsync(int id);
        Task<List<ProductSupplier>> GetProductSuppliersAsync();
        Task<ProductSupplier> AddProductSupplierAsync(ProductSupplier productSupplier);
        Task<bool> UpdateProductSupplierAsync(ProductSupplier productSupplier);
        Task<bool> DeleteProductSupplierAsync(int id);
    }
}
