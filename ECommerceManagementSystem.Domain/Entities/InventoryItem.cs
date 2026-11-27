using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public int ProductId { get; set; }
        public string Sku { get; set; } = string.Empty; // Unique Stock-Keeping Unit
        public string Name { get; set; } = string.Empty;
        public int QuantityOnHand { get; set; }
        public byte[] RowVersion { get; set; } = Array.Empty<byte>(); // Prevents race condition during concurrent stock updates

        // Navigation properties
        public Product Product { get; set; }
        public ICollection<Inventory_Transaction> InventoryTransactions { get; set; } = new List<Inventory_Transaction>();
    }
}
