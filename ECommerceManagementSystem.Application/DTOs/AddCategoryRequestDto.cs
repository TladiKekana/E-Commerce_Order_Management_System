using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record AddCategoryRequestDto
    (
        string Name,
        string Description
    );
}
