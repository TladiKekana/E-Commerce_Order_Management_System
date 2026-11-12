using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record AddProductRequestDto
    (
        string Name,
        int Category_Id,
        int Supplier_Id,
        string Description,
        string Sku,
        Decimal Price,
        string Status
    );
}
