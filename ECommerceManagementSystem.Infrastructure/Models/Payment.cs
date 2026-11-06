using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    public class Payment
    {
        public int Payment_Id { get; set; }
        public int Order_Id { get; set; }
        public int Transation_Id { get; set; }
        public string? Payment_Reference { get; set; }
        public string? Payment_Method { get; set; }
        public Decimal Amount { get; set; }
        public string? Payment_Status { get; set; }
        public DateTime Payment_Date { get; set; }

        // Navigation properties
        public Order Order { get; set; }
    }
}
