using ECommerceManagementSystem.Application.DTOs;
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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;

        public InventoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<InventoryItem?> GetInventoryItemAsync(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);

            return item;
        }

        public async Task<List<InventoryItem>> GetInventoryItemsAsync()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<InventoryItem> AddInventoryItemAsync(CreateInventoryItemDto dto, int userId)
        {
            var product = await _context.Products.FindAsync(dto.ProductId);
            var item = new InventoryItem 
            {
                Sku = dto.Sku,
                ProductId = dto.ProductId,
                QuantityOnHand = dto.InitialQuantity,
                Name = product.Name
            };

            if(dto.InitialQuantity > 0)
            {
                item.InventoryTransactions.Add(new Inventory_Transaction
                {
                    User_Id = userId,
                    Type = TransactionType.StockIn,
                    QuantityChanged = dto.InitialQuantity,
                    Notes = "Initial stock"
                });
            }

            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
