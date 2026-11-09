using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly DataContext _context;

        public InventoryTransactionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Inventory_Transaction> AddInventoryTransactionAsync(Inventory_Transaction inventoryTransaction)
        {
            _context.Inventory_Transactions.Add(inventoryTransaction);
            await _context.SaveChangesAsync();

            return inventoryTransaction;
        }

        public async Task<bool> DeleteInventoryTransactionAsync(int id)
        {
            var inventoryTransaction = await _context.Inventory_Transactions.FindAsync(id);

            if(inventoryTransaction == null)
                return false;

            _context.Inventory_Transactions.Remove(inventoryTransaction);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Inventory_Transaction> GetInventoryTransactionAsync(int id)
        {
            return await _context.Inventory_Transactions.FindAsync(id);
        }

        public async Task<List<Inventory_Transaction>> GetInventoryTransactionsAsync()
        {
            return await _context.Inventory_Transactions.ToListAsync();
        }

        public async Task<bool> UpdateInventoryTransactionAsync(Inventory_Transaction inventoryTransaction)
        {
            var currentInventoryTransaction = await _context.Inventory_Transactions.FindAsync(inventoryTransaction.Transaction_Id);

            if (currentInventoryTransaction == null)
                return false;

            _context.Inventory_Transactions.Entry(currentInventoryTransaction).CurrentValues.SetValues(inventoryTransaction);

            return true;
        }
    }
}
