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
        }

        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var orderCancelled = await _service.DeleteOrderAsync(id);

            if (!orderCancelled) return NotFound();
            
            return NoContent();
        }
    }
}
