using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Domain.Enums;
using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        //private readonly UserManager<Order> _userManager;
        private readonly DataContext _context;

        private readonly IOrderService _service;

        public OrderController(DataContext context, IOrderService service)
        {
            _context = context;
            _service = service;
            //_userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            if (!int.TryParse(User.FindFirstValue(JwtRegisteredClaimNames.Sub), out int userId))
                return BadRequest($"Invalid User id {User.FindFirstValue(ClaimTypes.NameIdentifier)}.");


            var order = await _service.GetOrderAsync(id, userId);

            if(order == null)
                return NotFound();

            return Ok(order.ToResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            if (!int.TryParse(User.FindFirstValue(JwtRegisteredClaimNames.Sub), out int userId))
                return BadRequest($"Invalid User id {userId}.");

            var orders = await _service.GetOrdersAsync(userId);

            if (orders == null)
                return NotFound();

            return Ok(orders.ToResponseDto());
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CreateOrderFromCart()
        {
            if (!int.TryParse(User.FindFirstValue(JwtRegisteredClaimNames.Sub), out int userId))
                return BadRequest("Invalid User id.");

            var order = await _service.CreateOrderFromCartAsync(userId);

            if (order == null)
                return BadRequest("Failed to place order");

            return Ok(order.ToResponseDto());

            /*using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
                    return BadRequest("Invalid User id.");

                var cart = await _context.Carts
                    .Include(c => c.CartItems)
                    .FirstOrDefaultAsync(c => c.User_Id == userId);

                if (cart == null || !cart.CartItems.Any())
                    return BadRequest("Cannot create an order from an empty cart.");

                // Map CartItems to OrderItems
                var order = new Order
                {
                    User_Id = userId,
                    Status = OrderStatus.Confirmed,
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
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }*/
        }
    }
}
