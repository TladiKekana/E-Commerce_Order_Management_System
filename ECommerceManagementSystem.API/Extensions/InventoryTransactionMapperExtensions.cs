using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;
using System.Runtime.CompilerServices;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class InventoryTransactionMapperExtensions
    {
        public static TransactionResponseDto ToResposeDto(this Inventory_Transaction entity)
        {
            var response = new TransactionResponseDto
                (
                    entity.Transaction_Id,
                    entity.InventotyItemId,
                    entity.User_Id,
                    entity.Type.ToString(),
                    entity.QuantityChanged,
                    entity.Transaction_Date,
                    entity.Notes
                );

            return response;
        }

        public static List<TransactionResponseDto> ToResposeDto(this List<Inventory_Transaction> entities)
        {
            var response = new List<TransactionResponseDto>();

            foreach ( var entity in entities )
            {
                response.Add(new TransactionResponseDto(
                        entity.Transaction_Id,
                        entity.InventotyItemId,
                        entity.User_Id,
                        entity.Type.ToString(),
                        entity.QuantityChanged,
                        entity.Transaction_Date,
                        entity.Notes
                    ));
            }

            return response;
        }
    }
}
