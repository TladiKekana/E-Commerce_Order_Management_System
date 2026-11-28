using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        Task<InventoryItem> GetInventoryItemAsync(int id);
        Task<List<InventoryItem>> GetInventoryItemsAsync();
        Task<InventoryItem> AddInventoryItemAsync(CreateInventoryItemDto item, int userId);
    }
}
