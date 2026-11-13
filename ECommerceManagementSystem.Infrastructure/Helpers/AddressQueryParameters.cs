using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Helpers
{
    public class AddressQueryParameters
    {
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? SortBy { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
