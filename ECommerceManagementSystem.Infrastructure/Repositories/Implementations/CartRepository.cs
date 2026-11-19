using ECommerceManagementSystem.Domain.Entities;
using ECommerceManagementSystem.Infrastructure.Data;
using ECommerceManagementSystem.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;

        public CartRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Cart> AddCartItemAsync(int UserId, int productId, int quantity)
        {
            var cart = await _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.User_Id == UserId);

            if(cart == null)
            {
                cart = new Cart { User_Id = UserId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var product = await _context.Products.FindAsync(productId);

            if(product == null)
                return cart;

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Cart_Id == cart.Cart_Id);

            if(cartItem == null)
            {
                cartItem = new CartItem 
                { 
                    Cart_Id = cart.Cart_Id,
                    Product_Id = productId,
                    Quantity = quantity
                };

                cart.CartItems.Add(cartItem);
            }
            else
                cartItem.Quantity += quantity;

            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<Cart> GetCartAsync(int UserId)
        {
            var cart = await _context.Carts
                .Include (c => c.User)
                .Include (c => c.CartItems)
                .FirstOrDefaultAsync(c => c.User_Id == UserId);
            var user = await _context.Users.FindAsync(UserId);

            if(cart == null)
            {
                cart = new Cart { User_Id = UserId  };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            if(user != null)
            {
                cart.User.Id = user.Id;
                cart.User.First_Name = user.First_Name;
                cart.User.Last_Name = user.Last_Name;
                cart.User.Email = user.Email;
            }

            return cart;
        }

        public async Task<bool> RemoveCartItemAsync(int UserId, int productId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.User_Id == UserId);

            var cartItem = cart?.CartItems.FirstOrDefault(ci => ci.Product_Id == productId);

            if (cartItem == null)
                return false;

            return true;
        }
    }
}
