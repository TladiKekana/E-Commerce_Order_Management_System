using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    public class Product
    {
        public int Product_Id { get; set; }
        public int Category_Id { get; set; }
        //public int Supplier_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }

        //Navigation Properties
        public virtual Category Category { get; set; }
        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public virtual OrderItem OrderItem { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
    }
}
