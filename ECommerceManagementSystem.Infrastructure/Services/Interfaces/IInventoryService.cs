using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<Inventory> GetInventoryAsync(int id);
        Task<List<Inventory>> GetInventoriesAsync();
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<bool> UpdateInventoryAsync(Inventory inventory);
        Task<bool> DeleteInventoryAsync(int id);
    }
}
