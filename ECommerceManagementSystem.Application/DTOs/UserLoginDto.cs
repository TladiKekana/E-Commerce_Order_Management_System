using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Application.DTOs
{
    public record UserLoginDto
    (
        string Email,
        string Password
    );
}
