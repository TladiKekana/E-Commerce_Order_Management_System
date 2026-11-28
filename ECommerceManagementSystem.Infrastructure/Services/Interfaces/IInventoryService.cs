using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<InventoryItem> GetInventoryItemAsync(int id);
        Task<List<InventoryItem>> GetInventoryItemsAsync();
        Task<InventoryItem> AddInventoryItemAsync(CreateInventoryItemDto item, int userId);
    }
}
