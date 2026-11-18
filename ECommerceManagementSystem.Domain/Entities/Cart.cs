using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class Cart
    {
        public int Cart_Id { get; set; }
        public int User_Id { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ApplicationUser User { get; set; } = null!;
    }
}
