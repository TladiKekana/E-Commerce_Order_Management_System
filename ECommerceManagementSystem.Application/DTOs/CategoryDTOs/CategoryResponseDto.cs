using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs.CategoryDTOs
{
    public record CategoryResponseDto
    (
        int Category_Id,
        string Name,
        string Description
    );
}
