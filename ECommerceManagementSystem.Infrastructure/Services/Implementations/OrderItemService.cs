using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItemService(IOrderItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            return await _repository.AddOrderItemAsync(orderItem);
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            return await _repository.DeleteOrderItemAsync(id);
        }

        public async Task<OrderItem> GetOrderItemAsync(int id)
        {
            return await _repository.GetOrderItemAsync(id);
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            return await _repository.GetOrderItemsAsync();
        }

        public async Task<bool> UpdateOrderItemAsync(OrderItem orderItem)
        {
            return await _repository.UpdateOrderItemAsync(orderItem);
        }
    }
}
