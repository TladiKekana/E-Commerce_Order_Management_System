using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    internal class Category
    {
        public int Category_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public int Parent_Category_Id { get; set; }

        // Navigation Properties
        public ICollection<Product> Products;
    }
}
