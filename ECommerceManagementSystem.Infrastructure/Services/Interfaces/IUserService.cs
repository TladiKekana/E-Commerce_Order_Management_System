using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(int id);
        Task<List<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> AddUserAsync(ApplicationUser user);
        //Task<bool> UpdateUserAsync(ApplicationUser user);
        Task<bool> DeleteUserAsync(int id);
    }
}
