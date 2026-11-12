using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Application.Validators;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IValidator<AddAddressRequestDto> _addAddressValidator;
        private readonly IValidator<UpdateAddressRequestDto> _updateAddressValidator;
        private readonly DataContext _context;

        public AddressController(IAddressService addressService, DataContext context,
            IValidator<AddAddressRequestDto> addAddressValidator,
            IValidator<UpdateAddressRequestDto> updateAddressValidator)
        {
            _addressService = addressService;
            _context = context;
            _addAddressValidator = addAddressValidator;
            _updateAddressValidator = updateAddressValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _addressService.GetAddressesAsync();

            if (addresses == null)
                return NotFound();

            return Ok(addresses.ToResponseDto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var address = await _addressService.GetAddressAsync(id);

            if (address == null)
                return NotFound();

            return Ok(address.ToResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressRequestDto address)
        {
            var validationResult = await _addAddressValidator.ValidateAsync(address);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var userExists = await _context.Users.AnyAsync(u => u.User_Id == address.User_Id);

            if (!userExists) 
                return BadRequest(new { message = $"User Id: {address.User_Id} does not exist" });

            var newAddress = await _addressService.AddAddressAsync(address.ToEntity());

            return CreatedAtAction(nameof(GetAddress), new { id = newAddress.Address_Id }, newAddress.ToResponseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var deleted = await _addressService.DeleteAddressAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, UpdateAddressRequestDto address)
        {
            if(id != address.Address_Id)
                return BadRequest();

            var validationResult = await _updateAddressValidator.ValidateAsync(address);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var userExists = await _context.Users.AnyAsync(u => u.User_Id == address.User_Id);

            if (!userExists)
                return BadRequest(new { message = $"User Id: {address.User_Id} does not exist" });

            var updated = await _addressService.UpdateAddressAsync(address.ToEntity());

            if(!updated)
                return NotFound();

            return NoContent();
        }
    }
}