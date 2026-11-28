using ECommerceManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record TransactionResponseDto
    (
        int TransactionId,
        int InventoryItemId,
        int UserId,
        string Type,
        int QuantityChanged,
        DateTime TransactionDate,
        string Notes
    );
}
