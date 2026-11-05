using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class ProductSupplierRepository : IProductSupplierRepository
    {
        private readonly DataContext _context;

        public ProductSupplierRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ProductSupplier> AddProductSupplierAsync(ProductSupplier productSupplier)
        {
            _context.ProductSuppliers.Add(productSupplier);
            await _context.SaveChangesAsync();

            return productSupplier;
        }

        public async Task<bool> DeleteProductSupplierAsync(int id)
        {
            var productSupplier = await _context.ProductSuppliers.FindAsync(id);

            if (productSupplier == null)
                return false;

            _context.ProductSuppliers.Remove(productSupplier);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ProductSupplier> GetProductSupplierAsync(int id)
        {
            return await _context.ProductSuppliers.FindAsync(id);
        }

        public async Task<List<ProductSupplier>> GetProductSuppliersAsync()
        {
            return await _context.ProductSuppliers.ToListAsync();
        }

        public async Task<bool> UpdateProductSupplierAsync(ProductSupplier productSupplier)
        {
            var currentProductSupplier = await _context.ProductSuppliers.FindAsync(productSupplier.ProcuctSupplier_Id);

            if(currentProductSupplier == null) 
                return false;

            _context.ProductSuppliers.Entry(currentProductSupplier).CurrentValues.SetValues(productSupplier);

            return true;
        }
    }
}
