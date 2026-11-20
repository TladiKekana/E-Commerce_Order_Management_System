using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<Supplier> GetSupplierAsync(int id);
        Task<List<Supplier>> GetSuppliersAsync(SupplierQueryParameters query);
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<bool> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
