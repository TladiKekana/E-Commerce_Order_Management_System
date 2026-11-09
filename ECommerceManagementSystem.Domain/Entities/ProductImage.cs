using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Domain.Entities
{
    public class ProductImage
    {
        public int Image_Id { get; set; }
        public int Product_Id { get; set; }
        public string? Image_Url { get; set; }
        public string? Alt_Text { get; set; }
        public bool Id_Primary { get; set; } // Indicates the main product image
        public int Display_Order { get; set; } // Image display sequence
        public DateTime Created_At { get; set; }

        // Navigation property
        public Product Product { get; set; }
    }
}
