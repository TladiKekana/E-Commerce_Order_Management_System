using ECommerceManagementSystem.Infrastructure.Models;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _repository.AddRoleAsync(role);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _repository.DeleteRoleAsync(id);
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            return await _repository.GetRoleAsync(id);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _repository.GetRolesAsync();
        }

        public async Task<bool> UpdateRoleAsync(Role role)
        {
            return await _repository.UpdateRoleAsync(role);
        }
    }
}
