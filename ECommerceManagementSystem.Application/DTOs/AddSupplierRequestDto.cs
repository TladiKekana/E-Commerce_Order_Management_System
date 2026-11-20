using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record AddSupplierRequestDto
    (
        string SupplierName,
        string ContactPerson,
        string Email,
        int Phone,
        string Address,
        string Status
    );
}
