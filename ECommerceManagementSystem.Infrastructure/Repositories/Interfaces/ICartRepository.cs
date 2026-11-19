using ECommerceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(int UserId);
        Task<Cart> AddCartItemAsync(int UserId, int productId, int quantity);
        Task<bool> RemoveCartItemAsync(int UserId, int productId);
    }
}
