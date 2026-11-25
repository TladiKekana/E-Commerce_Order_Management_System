using ECommerceManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record GetOrderDto
    (
        int Order_Id,
        int User_Id,
        //int Address_Id,
        string Order_Number,
        DateTime Order_Date,
        string Status,
        Decimal Total_Amount
    );
}
