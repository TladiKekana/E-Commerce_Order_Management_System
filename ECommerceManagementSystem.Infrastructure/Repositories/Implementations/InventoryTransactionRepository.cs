using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Enums;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly DataContext _context;

        public InventoryTransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Inventory_Transaction>> GetHistoryForItem(int id)
        {
            var history = await _context.Inventory_Transactions
                .Where(it => it.InventotyItemId == id)
                .OrderByDescending(it => it.Transaction_Date)
                .AsNoTracking()
                .ToListAsync();

            return history;
        }

        public async Task<Inventory_Transaction?> RecordTransaction(RecordTransactionDto dto)
        {
            int signedChange = 0;

            await using var dbTransanction = await _context.Database.BeginTransactionAsync();

            try
            {
                var item = await _context.InventoryItems.FindAsync(dto.InventoryItemId);

                if (item == null) // Item not found
                    return null;

                // Determine signed change based on transaction type
                switch (dto.Type)
                {
                    case TransactionType.StockIn: signedChange = dto.Quantity; break;
                    case TransactionType.StockOut: signedChange = -dto.Quantity; break;
                }

                if (item.QuantityOnHand + signedChange < 0) // Insuficient stock available
                    return null;

                item.QuantityOnHand += signedChange;

                var transaction = new Inventory_Transaction
                {
                    InventotyItemId = dto.InventoryItemId,
                    Type = dto.Type,
                    QuantityChanged = signedChange,
                    Notes = dto.ReferenceNote
                };

                _context.Inventory_Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                await dbTransanction.CommitAsync();

                return transaction;
            }
            catch (DbUpdateConcurrencyException) 
            {
                await dbTransanction.RollbackAsync();
                return null;
            }
            catch
            {
                await dbTransanction.RollbackAsync();
                throw;
            }
        }

        public async Task<Inventory_Transaction> AddInventoryTransactionAsync(Inventory_Transaction inventoryTransaction)
        {
            _context.Inventory_Transactions.Add(inventoryTransaction);
            await _context.SaveChangesAsync();

            return inventoryTransaction;
        }

        public async Task<bool> DeleteInventoryTransactionAsync(int id)
        {
            var inventoryTransaction = await _context.Inventory_Transactions.FindAsync(id);

            if(inventoryTransaction == null)
                return false;

            _context.Inventory_Transactions.Remove(inventoryTransaction);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Inventory_Transaction> GetInventoryTransactionAsync(int id)
        {
            return await _context.Inventory_Transactions.FindAsync(id);
        }

        public async Task<List<Inventory_Transaction>> GetInventoryTransactionsAsync()
        {
            return await _context.Inventory_Transactions.ToListAsync();
        }

        public async Task<bool> UpdateInventoryTransactionAsync(Inventory_Transaction inventoryTransaction)
        {
            var currentInventoryTransaction = await _context.Inventory_Transactions.FindAsync(inventoryTransaction.Transaction_Id);

            if (currentInventoryTransaction == null)
                return false;

            _context.Inventory_Transactions.Entry(currentInventoryTransaction).CurrentValues.SetValues(inventoryTransaction);

            return true;
        }
    }
}
