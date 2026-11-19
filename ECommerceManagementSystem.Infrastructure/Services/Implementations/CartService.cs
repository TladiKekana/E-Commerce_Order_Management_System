using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using ECommerceManagementSystem.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }
        public Task<Cart> AddCartItemAsync(int UserId, int productId, int quantity)
        {
            return _repository.AddCartItemAsync(UserId, productId, quantity);
        }

        public Task<Cart> GetCartAsync(int UserId)
        {
            return _repository.GetCartAsync(UserId);
        }

        public Task<bool> RemoveCartItemAsync(int UserId, int productId)
        {
            return _repository.RemoveCartItemAsync(UserId, productId);
        }
    }
}
