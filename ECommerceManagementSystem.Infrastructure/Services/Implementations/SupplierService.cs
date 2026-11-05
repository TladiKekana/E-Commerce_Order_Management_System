using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }
        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            return await _repository.AddSupplierAsync(supplier);
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            return await _repository.DeleteSupplierAsync(id);
        }

        public async Task<Supplier> GetSupplierAsync(int id)
        {
            return await _repository.GetSupplierAsync(id);
        }

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            return await _repository.GetSuppliersAsync();
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            return await _repository.UpdateSupplierAsync(supplier);
        }
    }
}
