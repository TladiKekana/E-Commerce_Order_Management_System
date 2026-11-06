using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    public class Address
    {
        public int Address_Id { get; set; }
        public int User_Id { get; set; }
        public string? Address_Type { get; set; } // Home, Work, billing, shipping
        public string? Street_Address { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Posta_Code { get; set; }
        public string? Country { get; set; }
        public bool Is_default { get; set; }
        public DateTime Created_At { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
