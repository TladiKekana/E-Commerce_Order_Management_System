using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Application.DTOs;
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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;
        private readonly DataContext _context;

        public InventoryController(IInventoryService service, DataContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryItem(int id)
        {
            var item = await _service.GetInventoryItemAsync(id);

            if(item == null) return NotFound();

            return Ok(item.ToResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoryItems()
        {
            var items = await _service.GetInventoryItemsAsync();

            if(items == null) return NotFound();

            return Ok(items.ToResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventoryItem(CreateInventoryItemDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (!int.TryParse(userId, out var id))
                return BadRequest("Invalid User Id.");

            var itemExists = await _context.InventoryItems.AnyAsync(ii => ii.Sku == dto.Sku);

            if (itemExists)
                return Conflict($"SKU {dto.Sku} already exists.");

            var product = await _context.Products.FindAsync(dto.ProductId);

            if(product == null)
                return NotFound("Product Id not found");

            var item = await _service.AddInventoryItemAsync(dto, id);

            return Ok(item.ToResponseDto());
        }
    }
}
