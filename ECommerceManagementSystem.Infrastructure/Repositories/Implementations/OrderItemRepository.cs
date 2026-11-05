using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _context;

        public OrderItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return orderItem;
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
                return false;

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<OrderItem> GetOrderItemAsync(int id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<bool> UpdateOrderItemAsync(OrderItem orderItem)
        {
            var currentOrderItem = await _context.OrderItems.FindAsync(orderItem.Order_Id);

            if (currentOrderItem == null)
                return false;

            _context.OrderItems.Entry(currentOrderItem).CurrentValues.SetValues(orderItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
