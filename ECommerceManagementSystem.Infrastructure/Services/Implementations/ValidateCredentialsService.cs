using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class ValidateCredentialsService : IValidateCredentialsService
    {
        private readonly IValidateCredentialsRepository _repository;

        public ValidateCredentialsService(IValidateCredentialsRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            return await _repository.GenerateJwtToken(user);
        }
    }
}
