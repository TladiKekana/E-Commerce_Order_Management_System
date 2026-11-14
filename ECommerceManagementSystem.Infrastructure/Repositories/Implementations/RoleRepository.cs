using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        /*private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if(role == null)
                return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<bool> UpdateRoleAsync(Role role)
        {
            var currentRole = await _context.Roles.FindAsync(role.Role_Id);

            if (currentRole == null)
                return false;

            _context.Roles.Entry(currentRole).CurrentValues.SetValues(role);
            await _context.SaveChangesAsync();

            return true;
        }*/
    }
}
