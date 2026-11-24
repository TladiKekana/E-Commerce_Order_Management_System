using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using ECommerceManagementSystem.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        //private string UserIdString => User.FindFirstValue(JwtRegisteredClaimNames.Sub)!;
        //private int UserId;
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
            //int.TryParse(UserIdString, out UserId);
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            int UserId;
            var UserIdString = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (!int.TryParse(UserIdString, out UserId))
              return BadRequest(new { message = "Invalid User Id" });

            var cart = await _service.GetCartAsync(UserId);

            return Ok(cart.CartItems.ToResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(AddCartItemDto request)
        {
            int UserId;
            var UserIdString = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (!int.TryParse(UserIdString, out UserId))
                return BadRequest(new { message = "Invalid User Id" });

            var cart = await _service.AddCartItemAsync(UserId, request.ProductId, request.Quantity);

            return Ok(cart.CartItems.ToResponseDto());
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCartItem([FromBody] int productId)
        {
            int UserId;
            var UserIdString = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (!int.TryParse(UserIdString, out UserId))
                return BadRequest(new { message = "Invalid User Id" });

            var itemRemoved = await _service.RemoveCartItemAsync(UserId, productId);

            if (!itemRemoved)
                return NotFound();

            return NoContent();
        }
    }
}
