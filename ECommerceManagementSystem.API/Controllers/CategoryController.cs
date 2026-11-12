using ECommerceManagementSystem.API.Extensions;
using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<AddCategoryRequestDto> _addCategoryValidator;
        private readonly IValidator<UpdateCategoryRequestDto> _updateCategoryValidator;

        public CategoryController(ICategoryService categoryService,
            IValidator<AddCategoryRequestDto> addCategoryValidator, 
            IValidator<UpdateCategoryRequestDto> updateCategoryValidator)
        {
            _categoryService = categoryService;
            _addCategoryValidator = addCategoryValidator;
            _updateCategoryValidator = updateCategoryValidator;
        }

        [HttpGet("{id}")] // GET: api/categories/1
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            if(category == null)
                return NotFound();

            return Ok(category.ToResponseDto());
        }

        [HttpGet] // GET: api/categories
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (categories == null)
                return NotFound();

            return Ok(categories.ToResponseDto());
        }

        [HttpPost] // POST: api/categories
        public async Task<IActionResult> AddCategory(AddCategoryRequestDto category)
        {
            var validationResult = await _addCategoryValidator.ValidateAsync(category);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var newCategory = await _categoryService.AddCategoryAsync(category.ToEntity());

            return CreatedAtAction(nameof(GetCategory), new {id = newCategory.Category_Id }, newCategory.ToResponseDto());
        }

        [HttpDelete("{id}")] // DELETE: api/categories/1
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")] // PUT: api/categories/1
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequestDto category)
        {
            if (id != category.Category_Id)
                return BadRequest();

            var validationResult = await _updateCategoryValidator.ValidateAsync(category);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var updated = await _categoryService.UpdateCategoryAsync(category.ToEntity());

            if(!updated)
                return NotFound();

            return NoContent();
        }
    }
}
