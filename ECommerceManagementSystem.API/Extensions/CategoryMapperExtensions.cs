using ECommerceManagementSystem.Application.DTOs.CategoryDTOs;
using ECommerceManagementSystem.Application.DTOs.ProductDTOs;
using ECommerceManagementSystem.Domain.Entities;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class CategoryMapperExtensions
    { 
        // Maps Entity to Response DTO
        public static CategoryResponseDto ToResponseDto(this Category category)
        {
            return new CategoryResponseDto(
                    category.Category_Id,
                    category.Name,
                    category.Description
                );
        }

        // Maps Request DTO to Entity
        public static Category ToEntity(this AddCategoryRequestDto request)
        {
            return new Category
            {
                Name = request.Name,
                Description = request.Description
            };
        }

        public static Category ToEntity(this UpdateCategoryRequestDto request)
        {
            return new Category
            {
                Name = request.Name,
                Description = request.Description
            };
        }
    }
}
