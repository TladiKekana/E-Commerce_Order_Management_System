using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class Inventory
    {
        public int Inventory_Id { get; set; }
        public int Product_Id { get; set; }
        public int Qty_Available { get; set; }
        public int Qty_Reserved { get; set; }
        public int Reoder_Level { get; set; } // Minimum stock threshold
        public DateTime Last_Updated { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public ICollection<Inventory_Transaction> Inventory_Transactions { get; set; } = new List<Inventory_Transaction>();
    }
}
