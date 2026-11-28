using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record InventoryItemResponseDto
    (
        int InventoryItemId,
        int ProductId,
        string Sku,
        string Name,
        int QuantityOnHand
    );
}
