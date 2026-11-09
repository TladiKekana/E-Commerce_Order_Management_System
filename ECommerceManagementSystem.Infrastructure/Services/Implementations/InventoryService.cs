using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;

        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            return await _repository.AddInventoryAsync(inventory);
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            return await _repository.DeleteInventoryAsync(id);
        }

        public async Task<List<Inventory>> GetInventoriesAsync()
        {
            return await _repository.GetInventoriesAsync();
        }

        public async Task<Inventory> GetInventoryAsync(int id)
        {
            return await _repository.GetInventoryAsync(id);
        }

        public async Task<bool> UpdateInventoryAsync(Inventory inventory)
        {
            return await _repository.UpdateInventoryAsync(inventory);
        }
    }
}
