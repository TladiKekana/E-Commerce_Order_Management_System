using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _addressService.GetAddressesAsync();

            if (addresses == null)
                return NotFound();

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var address = await _addressService.GetAddressAsync(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(Address address)
        {
            var newAddress = await _addressService.AddAddressAsync(address);

            return CreatedAtAction(nameof(GetAddress), new { id = newAddress.Address_Id }, newAddress);
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
        public async Task<IActionResult> UpdateAddress(int id, Address address)
        {
            if(id != address.Address_Id)
                return BadRequest();

            var updated = await _addressService.UpdateAddressAsync(address);

            if(!updated)
                return NotFound();

            return NoContent();
        }
    }
}