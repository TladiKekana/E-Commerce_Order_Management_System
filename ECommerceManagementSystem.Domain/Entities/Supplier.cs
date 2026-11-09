using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class Supplier
    {
        public int Supplier_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Contact_Person { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }

        //Navigation Properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
