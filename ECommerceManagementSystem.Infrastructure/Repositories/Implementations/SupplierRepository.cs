using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext _context;

        public SupplierRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return supplier;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if(supplier == null)
                return false;

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Supplier> GetSupplierAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            var currentSupplier = await _context.Suppliers.FindAsync(supplier.Supplier_Id);

            if (currentSupplier == null)
                return false;

            _context.Suppliers.Entry(currentSupplier).CurrentValues.SetValues(supplier);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
