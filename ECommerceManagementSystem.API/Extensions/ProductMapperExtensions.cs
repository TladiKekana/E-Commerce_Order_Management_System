using ECommerceManagementSystem.Application.DTOs.ProductDTOs;
using ECommerceManagementSystem.Domain.Entities;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class ProductMapperExtensions
    {
        // Maps Entity to Response DTO
        public static ProductResponseDto ToResponseDto(this Product product)
        {
            return new ProductResponseDto(
                    product.Product_Id,
                    product.Category_Id,
                    product.Supplier_Id,
                    product.Name,
                    product.Description,
                    product.Sku,
                    product.Price,
                    product.Status
                );
        }

        public static List<ProductResponseDto> ToResponseDto(this List<Product> products)
        {
            List<ProductResponseDto> productResponseDtos = new List<ProductResponseDto>();

            foreach( var product in products )
            {
                productResponseDtos.Add( new ProductResponseDto(
                        product.Product_Id,
                        product.Category_Id,
                        product.Supplier_Id,
                        product.Name,
                        product.Description,
                        product.Sku,
                        product.Price,
                        product.Status
                    ));
            }

            return productResponseDtos;
        }

        // Maps Request DTO to Entity
        public static Product ToEntity(this AddProductRequestDto request)
        {
            return new Product
            {
                Name = request.Name,
                Category_Id = request.Category_Id,
                Supplier_Id = request.Supplier_Id,
                Description = request.Description,
                Sku = request.Sku,
                Price = request.Price,
                Status = request.Status
            };
        }

        public static Product ToEntity(this UpdateProductRequestDto request)
        {
            return new Product
            {
                Name = request.Name,
                Category_Id = request.Category_Id,
                Supplier_Id = request.Supplier_Id,
                Description = request.Description,
                Sku = request.Sku,
                Price = request.Price,
                Status = request.Status
            };
        }
    }
}
