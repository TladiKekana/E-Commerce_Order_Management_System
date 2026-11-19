using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class CartMapperExtensions
    {
        public static GetCartDto ToResponseDto(this Cart cart)
        {
            return new GetCartDto
                (
                    cart.Cart_Id,
                    cart.User.Id,
                    cart.User.First_Name,
                    cart.User.Last_Name,
                    cart.CartItems
                );
        }
    }
}
