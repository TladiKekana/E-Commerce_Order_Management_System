using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    internal class OrderItem
    {
        public int Order_Item_Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public Decimal Unit_Price { get; set; }

        // Navigation Properties
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
