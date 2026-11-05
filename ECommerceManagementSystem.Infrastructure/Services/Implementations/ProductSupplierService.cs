using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class ProductSupplierService : IProductSupplierService
    {
        private readonly IProductSupplierRepository _repository;

        public ProductSupplierService(IProductSupplierRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductSupplier> AddProductSupplierAsync(ProductSupplier productSupplier)
        {
            return await _repository.AddProductSupplierAsync(productSupplier);
        }

        public async Task<bool> DeleteProductSupplierAsync(int id)
        {
            return await _repository.DeleteProductSupplierAsync(id);
        }

        public async Task<ProductSupplier> GetProductSupplierAsync(int id)
        {
            return await _repository.GetProductSupplierAsync(id);
        }

        public async Task<List<ProductSupplier>> GetProductSuppliersAsync()
        {
            return await _repository.GetProductSuppliersAsync();
        }

        public async Task<bool> UpdateProductSupplierAsync(ProductSupplier productSupplier)
        {
            return await _repository.UpdateProductSupplierAsync(productSupplier);
        }
    }
}
