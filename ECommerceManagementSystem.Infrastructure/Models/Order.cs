using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int User_Id { get; set; }
        public int Address_Id { get; set; }
        public string? Order_Number { get; set; }
        public DateTime Order_Date { get; set; }
        public string? Status { get; set; }
        public Decimal Total_Amount { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Address Address { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
    }
}
