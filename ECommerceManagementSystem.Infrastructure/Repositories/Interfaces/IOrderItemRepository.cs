using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetOrderItemAsync(int id);
        Task<List<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<bool> UpdateOrderItemAsync(OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int id);
    }
}
