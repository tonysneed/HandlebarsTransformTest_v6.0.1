using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NoTransform_Annotations.Models.dbo
{ // Comment
    [Table("Customer")]
    public partial class Customer : EntityBase // My Handlebars Helper
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(5)]
        public string CustomerId { get; set; } = null!;
        [StringLength(40)]
        public string CompanyName { get; set; } = null!;
        [StringLength(30)]
        public string? ContactName { get; set; }
        [StringLength(15)]
        public string? City { get; set; }
        [StringLength(15)]
        public string? Country { get; set; }

        [InverseProperty("Customer")]
        public virtual CustomerSetting CustomerSetting { get; set; } = null!;
        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
