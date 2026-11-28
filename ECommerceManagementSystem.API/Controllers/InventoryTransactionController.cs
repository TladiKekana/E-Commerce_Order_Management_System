using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Domain.Enums;
using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InventoryTransactionController : ControllerBase
    {
        private readonly DataContext _context;

        public InventoryTransactionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryForItem(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);

            if(item == null)
                return NotFound("InventoryItem Id not found");

            var history = await _context.Inventory_Transactions
                .Where(it => it.InventotyItemId == id)
                .OrderByDescending(it => it.Transaction_Date)
                .AsNoTracking()
                .ToListAsync();

            return Ok(history.ToResposeDto());
        }

        [HttpPost]
        public async Task<IActionResult> RecordTransaction(RecordTransactionDto dto)
        {
            var userIdString = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (!int.TryParse(userIdString, out var userId))
                return BadRequest("Invalid User Id");

            int signedChange = 0;

            await using var dbTransaction = await _context.Database.BeginTransactionAsync();

            try 
            {
                var item = await _context.InventoryItems.FindAsync(dto.InventoryItemId);

                if (item == null)
                    return NotFound($"Inventory item {dto.InventoryItemId} not found");

                // Determine signed change based on transaction type
                switch(dto.Type)
                {
                    case TransactionType.StockIn: signedChange = dto.Quantity; break;
                    case TransactionType.StockOut: signedChange = -dto.Quantity; break;
                }

                if (item.QuantityOnHand + signedChange < 0)
                    return BadRequest("Insuficient stock available for this transaction");

                item.QuantityOnHand += signedChange;

                var transaction = new Inventory_Transaction 
                {
                    User_Id = userId,
                    InventotyItemId = item.InventoryItemId,
                    Type = dto.Type,
                    QuantityChanged = signedChange,
                    Notes = dto.ReferenceNote
                };

                _context.Inventory_Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                await dbTransaction.CommitAsync();

                return Ok(transaction.ToResposeDto());
            }
            catch(DbUpdateConcurrencyException) 
            {
                await dbTransaction.RollbackAsync();
                return Conflict("Stock was modified by another request. Please retry.");
            }
            catch 
            {
                await dbTransaction.RollbackAsync();
                throw;
            }
        }
    }
}
