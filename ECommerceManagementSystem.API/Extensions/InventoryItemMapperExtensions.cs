using ECommerceManagementSystem.Application.DTOs;
using ECommerceManagementSystem.Domain.Entities;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class InventoryItemMapperExtensions
    {
        public static InventoryItemResponseDto ToResponseDto(this InventoryItem entity)
        {
            var response = new InventoryItemResponseDto(
                    entity.InventoryItemId,
                    entity.ProductId,
                    entity.Sku,
                    entity.Name,
                    entity.QuantityOnHand
                );

            return response;
        }

        public static List<InventoryItemResponseDto> ToResponseDto(this List<InventoryItem> entities)
        {
            var response = new List<InventoryItemResponseDto>();

            foreach( var entity in entities )
            {
                response.Add(new InventoryItemResponseDto(
                        entity.InventoryItemId,
                        entity.ProductId,
                        entity.Sku,
                        entity.Name,
                        entity.QuantityOnHand
                    ));
            }

            return response;
        }
    }
}
