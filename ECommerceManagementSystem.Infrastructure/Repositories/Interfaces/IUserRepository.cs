using ECommerceManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<List<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
