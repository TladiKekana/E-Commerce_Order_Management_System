using ECommerceManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record RecordTransactionDto
    (
        int InventoryItemId,
        TransactionType Type,
        int Quantity,
        string? ReferenceNote
    );
}
