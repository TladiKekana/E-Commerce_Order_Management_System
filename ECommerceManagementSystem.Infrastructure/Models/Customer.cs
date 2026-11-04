using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    internal class Customer
    {
        public int Customer_Id { get; set; }
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int Phone { get; set; }
        public DateTime Registration_Time { get; set; }

        // Navigation Properties
        public ICollection<Order> Orders { get; set; }
    }
}
