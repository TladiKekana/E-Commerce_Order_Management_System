using ECommerceManagementSystem.Application.DTOs;
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
        public Task<InventoryItem> AddInventoryItemAsync(CreateInventoryItemDto item, int userId)
        {
            return _repository.AddInventoryItemAsync(item, userId);
        }

        public Task<InventoryItem> GetInventoryItemAsync(int id)
        {
            return _repository.GetInventoryItemAsync(id);
        }

        public Task<List<InventoryItem>> GetInventoryItemsAsync()
        {
            return _repository.GetInventoryItemsAsync();
        }
    }
}
