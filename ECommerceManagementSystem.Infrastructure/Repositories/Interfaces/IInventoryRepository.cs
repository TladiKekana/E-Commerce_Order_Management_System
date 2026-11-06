using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory> GetInventoryAsync(int id);
        Task<List<Inventory>> GetInventoriesAsync();
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<bool> UpdateInventoryAsync(Inventory inventory);
        Task<bool> DeleteInventoryAsync(int id);
    }
}
