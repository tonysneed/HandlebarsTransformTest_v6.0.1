using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample1.Models.dbo
{ // Comment
    [Table("Order")]
    public partial class OrderFoo : EntityBase // My Handlebars Helper
    {
        public OrderFoo()
        {
            OrderDetailsFoo = new HashSet<OrderDetailFoo>();
        }

        [Key]
        [Column("OrderId")]
        public int OrderIdFoo { get; set; }
        [Column("CustomerId")]
        [StringLength(5)]
        public string? CustomerIdFoo { get; set; }
        [Column("OrderDate", TypeName = "datetime")]
        public DateTime? OrderDateFoo { get; set; }
        [Column("ShippedDate", TypeName = "datetime")]
        public DateTime? ShippedDateFoo { get; set; }
        [Column("ShipVia")]
        public int? ShipViaFoo { get; set; }
        [Column("Freight", TypeName = "money")]
        public decimal? FreightFoo { get; set; }

        [ForeignKey(nameof(CustomerIdFoo))]
        [InverseProperty("OrdersFoo")]
        public virtual CustomerFoo? CustomerFoo { get; set; }
        [InverseProperty(nameof(OrderDetailFoo.OrderFoo))]
        public virtual ICollection<OrderDetailFoo> OrderDetailsFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
