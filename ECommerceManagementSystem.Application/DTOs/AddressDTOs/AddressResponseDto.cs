using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs.AddressDTOs
{
    public record AddressResponseDto(
        int Address_Id,
        int User_Id,
        string Address_Type,
        string Street_Address,
        string City,
        string Province,
        string Posta_Code,
        string Country
        );
}
