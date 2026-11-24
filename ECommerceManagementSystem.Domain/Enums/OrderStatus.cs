using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Enums
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled
    }
}
