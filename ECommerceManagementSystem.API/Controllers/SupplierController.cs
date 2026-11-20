using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Application.Validators;
using ECommerceManagementSystem.Infrastructure.Helpers;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;
        private readonly IValidator<AddSupplierRequestDto> _addSupplierValidator;
        private readonly IValidator<UpdateSupplierRequestDto> _updateSupplierValidator;

        public SupplierController(ISupplierService service, IValidator<UpdateSupplierRequestDto> updateSupplierValidator,
            IValidator<AddSupplierRequestDto> addSupplierValidator)
        {
            _service = service;
            _updateSupplierValidator = updateSupplierValidator;
            _addSupplierValidator = addSupplierValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var supplier = await _service.GetSupplierAsync(id);

            if(supplier == null)
                return NotFound();

            return Ok(supplier.ToResponseDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers([FromQuery] SupplierQueryParameters query)
        {
            var suppliers = await _service.GetSuppliersAsync(query);

            if(suppliers == null) return NotFound();

            return Ok(suppliers.ToResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(AddSupplierRequestDto request)
        {
            var validationResult = await _addSupplierValidator.ValidateAsync(request);

            if(!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var newSupplier = await _service.AddSupplierAsync(request.ToEntity());

            return CreatedAtAction(nameof(GetSupplier), new { id = newSupplier.Supplier_Id }, newSupplier.ToResponseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, UpdateSupplierRequestDto request)
        {
            if(id != request.SupplierId)
                return BadRequest();

            var validateResult = await _updateSupplierValidator.ValidateAsync(request);

            if(!validateResult.IsValid)
                return BadRequest(validateResult.Errors);

            var updated = await _service.UpdateSupplierAsync(request.ToEntity());

            if(!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSupplier(int id)
        {
            var removed = await _service.DeleteSupplierAsync(id);

            if(!removed) return NotFound();

            return NoContent();
        }
    }
}
