using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Infrastructure.Helpers;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetCategoriesAsync(CategoryQueryParameters query)
        {
            var categories = _context.Categories.AsQueryable();

            // Sorting
            if(!string.IsNullOrEmpty(query.SortBy))
            {
                switch(query.SortBy.ToLower())
                {
                    case "name": categories = categories.OrderBy(c => c.Name); break;
                    default : categories = categories.OrderBy(c => c.Category_Id); break; 
                }
            }

            // Pagination
            categories = categories
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);

            return await categories.ToListAsync();
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var currentCategory = await _context.Categories.FindAsync(category.Category_Id);

            if (currentCategory == null)
                return false;

            _context.Entry(currentCategory).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
