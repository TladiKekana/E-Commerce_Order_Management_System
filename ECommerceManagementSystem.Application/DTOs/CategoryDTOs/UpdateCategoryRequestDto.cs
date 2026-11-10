using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs.CategoryDTOs
{
    public record UpdateCategoryRequestDto(
            string Name,
            string Description
        );
}
