using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample1.Models.dbo
{ // Comment
    [Table("Customer")]
    public partial class CustomerFoo : EntityBase // My Handlebars Helper
    {
        public CustomerFoo()
        {
            OrdersFoo = new HashSet<OrderFoo>();
        }

        [Key]
        [Column("CustomerId")]
        [StringLength(5)]
        public string CustomerIdFoo { get; set; } = null!;
        [Column("CompanyName")]
        [StringLength(40)]
        public string CompanyNameFoo { get; set; } = null!;
        [Column("ContactName")]
        [StringLength(30)]
        public string? ContactNameFoo { get; set; }
        [Column("City")]
        [StringLength(15)]
        public string? CityFoo { get; set; }
        [Column("Country")]
        [StringLength(15)]
        public string? CountryFoo { get; set; }

        [InverseProperty("CustomerFoo")]
        public virtual CustomerSettingFoo CustomerSettingFoo { get; set; } = null!;
        [InverseProperty(nameof(OrderFoo.CustomerFoo))]
        public virtual ICollection<OrderFoo> OrdersFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
