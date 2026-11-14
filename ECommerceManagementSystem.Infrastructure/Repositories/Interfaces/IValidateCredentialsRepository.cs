using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IValidateCredentialsRepository
    {
        Task<string> GenerateJwtToken(ApplicationUser user);
    }
}
