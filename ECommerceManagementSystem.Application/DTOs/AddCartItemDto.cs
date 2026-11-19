using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record AddCartItemDto
    (
        int ProductId,
        int Quantity
    );
}
