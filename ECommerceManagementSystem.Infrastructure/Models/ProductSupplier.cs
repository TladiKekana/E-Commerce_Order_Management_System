using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    internal class ProductSupplier
    {
        public int ProcuctSupplier_Id { get; set; }
        public int Product_Id { get; set; }
        public int Supplier_Id { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
