using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;

        public InventoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return inventory;
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
                return false;

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Inventory>> GetInventoriesAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<bool> UpdateInventoryAsync(Inventory inventory)
        {
            var currentInventory = await _context.Inventories.FindAsync(inventory.Inventory_Id);

            if (currentInventory == null)
                return false;

            _context.Inventories.Entry(currentInventory).CurrentValues.SetValues(inventory);

            return true;
        }
    }
}
