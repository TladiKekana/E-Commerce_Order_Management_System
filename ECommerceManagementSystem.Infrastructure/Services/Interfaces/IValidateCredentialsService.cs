using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IValidateCredentialsService
    {
        Task<string> GenerateJwtToken(ApplicationUser user);
    }
}
