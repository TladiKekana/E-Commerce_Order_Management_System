using System;
using System.Collections.Generic;
using System.Text;
using ECommerceManagementSystem.Domain.Entities;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record GetCartItemsDto
    (
        //int CardId,
        //int UserId,
        //string UserFirstName,
        //string UserLastName,
        //List<CartItem>? CartItems = null,
        int ProductId,
        Decimal UnitPrice,
        int Quatity
    );
}
