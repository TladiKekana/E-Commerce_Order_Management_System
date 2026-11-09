using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItem> GetOrderItemAsync(int id);
        Task<List<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<bool> UpdateOrderItemAsync(OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int id);
    }
}
