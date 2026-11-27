using ECommerceManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class Inventory_Transaction
    {
        public int Transaction_Id { get; set; }
        public int InventotyItemId { get; set; }
        
        //public int Inventory_Id { get; set; }
        
        public int User_Id { get; set; }
        public TransactionType Type { get; set; }
        public int QuantityChanged { get; set; } // Positive for addition, negative for deduction

        //public string? Ref_Number { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string? Notes { get; set; } // Additional information

        // Navigation properties
        public InventoryItem Item { get; set; }
        public ApplicationUser User { get; set; }
    }
}
