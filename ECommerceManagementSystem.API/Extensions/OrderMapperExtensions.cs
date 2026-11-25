using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Domain.Enums;
using System.Net.NetworkInformation;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class OrderMapperExtensions
    {
        public static GetOrderDto ToResponseDto(this Order order)
        {
            return new GetOrderDto
                (
                    order.Order_Id,
                    order.User_Id,
                    //order.Address_Id,
                    order.Order_Number,
                    order.Order_Date,
                    order.Status.ToString(),
                    order.Total_Amount
                );
        }

        public static List<GetOrderDto> ToResponseDto(this List<Order> orders)
        {
            var ordersDto = new List<GetOrderDto>();

            foreach ( var order in orders )
            {
                ordersDto.Add(new GetOrderDto(
                        order.Order_Id,
                        order.User_Id,
                        order.Order_Number,
                        order.Order_Date,
                        order.Status.ToString(),
                        order.Total_Amount
                        )
                    );
            }

            return ordersDto;
        }
    }
}
