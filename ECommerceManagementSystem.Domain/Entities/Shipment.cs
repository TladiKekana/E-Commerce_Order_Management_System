using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class Shipment
    {
        public int Shipment_Id { get; set; }
        public int Order_Id { get; set; }
        public string? Tracking_Number { get; set; }
        public string? Carrier { get; set; }
        public string? Status { get; set; }
        public DateTime Shiping_Date { get; set; }
        public DateTime Estimated_Delivery_Date { get; set; }
        public DateTime Actual_Delivery_Date { get; set; }
        public Decimal Shipping_Cost { get; set; }

        // Navigation properties
        public Order Order { get; set; }
    }
}
