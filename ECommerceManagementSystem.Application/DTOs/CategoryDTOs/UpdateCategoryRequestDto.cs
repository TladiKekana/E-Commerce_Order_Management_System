using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs.CategoryDTOs
{
    public record UpdateCategoryRequestDto(
            int Category_Id,
            string Name,
            string Description
        );
}
