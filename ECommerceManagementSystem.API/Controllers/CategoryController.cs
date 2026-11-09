using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")] // GET: api/categories/1
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet] // GET: api/categories
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        [HttpPost] // POST: api/categories
        public async Task<IActionResult> AddCategory(Category category)
        {
            var newCategory = await _categoryService.AddCategoryAsync(category);

            return CreatedAtAction(nameof(GetCategory), new {id = newCategory.Category_Id }, newCategory);
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
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.Category_Id)
                return BadRequest();

            var updated = await _categoryService.UpdateCategoryAsync(category);

            if(!updated)
                return NotFound();

            return NoContent();
        }
    }
}
