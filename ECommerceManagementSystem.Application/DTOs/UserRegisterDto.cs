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
        string Password
    );
}
