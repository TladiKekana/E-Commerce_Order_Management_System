using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class CartItem
    {
        public int CartItem_Id { get; set; }
        public int Cart_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public Product Product { get; set; } = null!;
        public Cart Cart { get; set; } = null!;
    }
}
