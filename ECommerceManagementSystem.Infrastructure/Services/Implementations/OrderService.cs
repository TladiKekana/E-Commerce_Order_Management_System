using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            return await _repository.AddOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _repository.DeleteOrderAsync(id);
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _repository.GetOrderAsync(id);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _repository.GetOrdersAsync();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _repository.UpdateOrderAsync(order);
        }
    }
}
