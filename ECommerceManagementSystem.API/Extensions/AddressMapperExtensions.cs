using ECommerceManagementSystem.Application.DTOs.AddressDTOs;
using ECommerceManagementSystem.Application.DTOs.CategoryDTOs;
using ECommerceManagementSystem.Domain.Entities;
using System.Diagnostics.Metrics;
using System.Net;

namespace ECommerceManagementSystem.API.Extensions
{
    public static class AddressMapperExtensions
    {
        // Maps Entity to Response DTO
        public static AddressResponseDto ToResponseDto(this Address address)
        {
            return new AddressResponseDto(
                    address.Address_Id,
                    address.User_Id,
                    address.Address_Type,
                    address.Street_Address,
                    address.City,
                    address.Province,
                    address.Posta_Code,
                    address.Country
                );
        }

        public static List<AddressResponseDto> ToResponseDto(this List<Address> addresses)
        {
            List<AddressResponseDto> addressResponseDtos = new List<AddressResponseDto>();

            foreach (var address in addresses)
            {
                addressResponseDtos.Add(new AddressResponseDto(
                        address.Address_Id,
                        address.User_Id,
                        address.Address_Type,
                        address.Street_Address,
                        address.City,
                        address.Province,
                        address.Posta_Code,
                        address.Country
                    ));
            }

            return addressResponseDtos;
        }

        // Maps Request DTO to Entity
        public static Address ToEntity(this AddAddressRequestDto request)
        {
            return new Address
            {
                User_Id = request.User_Id,
                Address_Type = request.Address_Type,
                Street_Address = request.Street_Address,
                City = request.City,
                Province = request.Province,
                Posta_Code = request.Posta_Code,
                Country = request.Country
            };
        }

        public static Address ToEntity(this UpdateAddressRequestDto request)
        {
            return new Address
            {
                User_Id = request.User_Id,
                Address_Type = request.Address_Type,
                Street_Address = request.Street_Address,
                City = request.City,
                Province = request.Province,
                Posta_Code = request.Posta_Code,
                Country = request.Country
            };
        }
    }
}
