using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    public class Product
    {
        public int Product_Id { get; set; }
        public int Category_Id { get; set; }
        public int Supplier_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Sku { get; set; } // Unique Stock-Keeping Unit
        public Decimal Price { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        //Navigation Properties
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public OrderItem OrderItem { get; set; }
        public Inventory Inventory { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
