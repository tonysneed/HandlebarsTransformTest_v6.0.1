using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample.Models.dbo
{ // Comment
    [Table("OrderDetail")]
    public partial class OrderDetailFoo : EntityBase // My Handlebars Helper
    {
        [Key]
        [Column("OrderDetailId")]
        public int OrderDetailIdFoo { get; set; }
        [Column("OrderId")]
        public int OrderIdFoo { get; set; }
        [Column("ProductId")]
        public int ProductIdFoo { get; set; }
        [Column("UnitPrice", TypeName = "money")]
        public decimal UnitPriceFoo { get; set; }
        [Column("Quantity")]
        public short QuantityFoo { get; set; }
        [Column("Discount")]
        public float DiscountFoo { get; set; }

        [ForeignKey(nameof(OrderIdFoo))]
        [InverseProperty("OrderDetailsFoo")]
        public virtual OrderFoo OrderFoo { get; set; } = null!;
        [ForeignKey(nameof(ProductIdFoo))]
        [InverseProperty("OrderDetailsFoo")]
        public virtual ProductFoo ProductFoo { get; set; } = null!;

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
