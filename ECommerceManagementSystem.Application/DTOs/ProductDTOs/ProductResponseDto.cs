using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs.ProductDTOs
{
    public record ProductResponseDto
    (
        int Product_Id,
        int Category_Id,
        int Supplier_Id,
        string Name,
        string Description,
        string Sku,
        Decimal Price,
        string Status
    );
}
