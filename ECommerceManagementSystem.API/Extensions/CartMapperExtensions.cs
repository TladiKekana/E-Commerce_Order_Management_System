using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class CartMapperExtensions
    {
        public static List<GetCartItemsDto> ToResponseDto(this List<CartItem> cartItems)
        {
            var response = new List<GetCartItemsDto>();

            foreach (var item in cartItems)
            {
                response.Add(new GetCartItemsDto(
                        item.Product_Id,
                        item.UnitPrice,
                        item.Quantity
                    ));
            }

            return response;
        }
    }
}
