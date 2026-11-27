using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record CreateInventoryItemDto
    (
        string Sku,
        int ProductId,
        int InitialQuantity
    );
}
