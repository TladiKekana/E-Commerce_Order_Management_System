using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record UpdateCategoryRequestDto(
            int Category_Id,
            string Name,
            string Description
        );
}
