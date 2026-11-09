using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class Category
    {
        public int Category_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }

        // Navigation Properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
