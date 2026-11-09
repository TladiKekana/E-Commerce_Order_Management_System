using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class User
    {
        public int User_Id { get; set; }
        public int Role_Id { get; set; }
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Password_Hash { get; set; }
        public int Phone { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        // Navigation Properties
        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Inventory_Transaction> Inventory_Transactions { get; set; } = new List<Inventory_Transaction>();
    }
}
