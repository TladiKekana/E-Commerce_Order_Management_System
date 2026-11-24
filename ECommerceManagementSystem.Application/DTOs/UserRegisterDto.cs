using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record UserRegisterDto
    (
        string First_Name,
        string Last_Name,
        string Email,
        string Password,
        string StreetAddress,
        string City,
        string Province,
        string PostalCode,
        string Country
    );
}
