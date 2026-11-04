using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    internal class Order
    {
        public int Order_Id { get; set; }
        public int Customer_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public string? Status { get; set; }
        public Decimal Total_Amount { get; set; }

        // Navigation Properties
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
    }
}
