using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManagementSystem.Infrastructure.Models
{
    public class Role
    {
        public int Role_Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
