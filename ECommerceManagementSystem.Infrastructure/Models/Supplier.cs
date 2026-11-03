using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    internal class Supplier
    {
        public int Supplier_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Contact_Name { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }
        public string? Address { get; set; }

        //Navigation Properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
