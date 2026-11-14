using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApplicationUser> AddUserAsync(ApplicationUser user)
        {
            return await _repository.AddUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _repository.DeleteUserAsync(id);
        }

        public async Task<ApplicationUser> GetUserAsync(int id)
        {
            return await _repository.GetUserAsync(id);
        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }

        /*public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            return await _repository.UpdateUserAsync(user);
        }*/
    }
}
