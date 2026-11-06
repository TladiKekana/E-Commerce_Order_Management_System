using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IInventoryTransactionRepository _repository;

        public InventoryTransactionService(IInventoryTransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Inventory_Transaction> AddInventoryTransactionAsync(Inventory_Transaction inventoryTransaction)
        {
            return await _repository.AddInventoryTransactionAsync(inventoryTransaction);
        }

        public async Task<bool> DeleteInventoryTransactionAsync(int id)
        {
            return await _repository.DeleteInventoryTransactionAsync(id);
        }

        public async Task<Inventory_Transaction> GetInventoryTransactionAsync(int id)
        {
            return await _repository.GetInventoryTransactionAsync(id);
        }

        public async Task<List<Inventory_Transaction>> GetInventoryTransactionsAsync()
        {
            return await _repository.GetInventoryTransactionsAsync();
        }

        public async Task<bool> UpdateInventoryTransactionAsync(Inventory_Transaction inventoryTransaction)
        {
            return await _repository.UpdateInventoryTransactionAsync(inventoryTransaction);
        }
    }
}
