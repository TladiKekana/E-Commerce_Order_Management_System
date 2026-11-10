using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs.ProductDTOs
{
    public record UpdateProductRequestDto(
            string Name,
            int Category_Id,
            int Supplier_Id,
            string Description,
            string Sku,
            Decimal Price,
            string Status
        );
}
