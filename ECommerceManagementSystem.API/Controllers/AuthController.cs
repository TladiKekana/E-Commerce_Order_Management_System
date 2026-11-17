using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IValidateCredentialsService _service;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthController(IValidateCredentialsService service, IConfiguration configuration, 
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _service = service;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto model)
        {
            var user = new ApplicationUser 
            { 
                UserName = model.Email, 
                Email = model.Email, 
                First_Name = model.First_Name,
                Last_Name = model.Last_Name
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new { Message = "Invalid credentials." });

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = await _service.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(AddRoleRequestDto model)
        {
            var newRole = new ApplicationRole
            {
                Name = model.role
            };

            var result = await _roleManager.CreateAsync(newRole);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "Role added successfully" });
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole(AssignRoleRequestDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return BadRequest("User not found");

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            if (result.Succeeded)
                return Ok(new { message = "Role assigned successfully" });

            return BadRequest(result.Errors);
        }

        /*[Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser(ClaimsPrincipal user)
        {
            string? userEmail = "";
            var claims = user.Claims.Select(c => new { c.Type, c.Value });

            foreach (var claim in claims)
            {
                if (claim.Type == "email" && claim.Value == null)
                {
                    userEmail = claim.Value;
                    return Unauthorized();
                }
            }

            return Ok(new
            {
                userEmail
            });

            // Extracts the user ID from the JWT 'sub' or 'NameIdentifier' claim
            /*var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return NotFound("User not found.");

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new
            {
                user.Id,
                user.Email,
                user.UserName,
                Roles = roles
            });
        }*/
    }
}
