using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderFromCartAsync(int userId);
        Task<Order> GetOrderAsync(int id, int userId);
        Task<List<Order>> GetOrdersAsync(int userId);
        Task<Order> AddOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> CancelOrderAsync(int id);
    }
}
