using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample_Annotations.Models.dbo
{ // Comment
    [Table("OrderDetail")]
    public partial class OrderDetail : EntityBase // My Handlebars Helper
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; } = null!;
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; } = null!;

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
