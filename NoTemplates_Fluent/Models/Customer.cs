using System;
using System.Collections.Generic;

namespace NoTemplates_Fluent.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual CustomerSetting CustomerSetting { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
