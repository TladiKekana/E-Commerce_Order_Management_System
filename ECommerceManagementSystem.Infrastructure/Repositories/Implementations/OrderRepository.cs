using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Domain.Enums;
using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order?> CreateOrderFromCartAsync(int userId)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.User_Id == userId);

            if (address == null)
                return null;

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.User_Id == userId);

            if (cart == null || !cart.CartItems.Any())
                return null;

            // Map CartItems to OrderItems
            var order = new Order
            {
                User_Id = userId,
                Status = OrderStatus.Confirmed,
                Address_Id = address.Address_Id,
                OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    Product_Id = ci.Product_Id,
                    Unit_Price = ci.UnitPrice,
                    Quantity = ci.Quantity
                }).ToList()
            };

            order.Total_Amount = order.OrderItems.Sum(oi => oi.Unit_Price * oi.Quantity);

            _context.Orders.Add(order);

            // Clear User's cart
            _context.CartItems.RemoveRange(cart.CartItems);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Order> GetOrderAsync(int id, int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user.Orders.FirstOrDefault(o => o.User_Id == userId);
        }

        public async Task<List<Order>> GetOrdersAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user.Orders.ToList();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            var currentOrder = await _context.Orders.FindAsync(order.Order_Id);

            if (currentOrder == null)
                return false;

            _context.Entry(currentOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
