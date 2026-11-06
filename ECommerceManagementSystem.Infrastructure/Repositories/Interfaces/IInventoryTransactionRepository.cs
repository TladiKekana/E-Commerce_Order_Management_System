using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IInventoryTransactionRepository
    {
        Task<Inventory_Transaction> GetInventoryTransactionAsync(int id);
        Task<List<Inventory_Transaction>> GetInventoryTransactionsAsync();
        Task<Inventory_Transaction> AddInventoryTransactionAsync(Inventory_Transaction inventoryTransaction);
        Task<bool> UpdateInventoryTransactionAsync(Inventory_Transaction inventoryTransaction);
        Task<bool> DeleteInventoryTransactionAsync(int id);
    }
}
