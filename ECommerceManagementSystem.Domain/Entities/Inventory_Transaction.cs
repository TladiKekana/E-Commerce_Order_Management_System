using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class Inventory_Transaction
    {
        public int Transaction_Id { get; set; }
        public int Inventory_Id { get; set; }
        public int User_Id { get; set; }
        public string? Transaction_Type { get; set; } // Stock-in, stock-out, adjustment, return
        public int Quantity { get; set; }
        public string? Ref_Number { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string? Notes { get; set; } // Additional information

        // Navigation properties
        public Inventory Inventory { get; set; }
        public User User { get; set; }
    }
}
