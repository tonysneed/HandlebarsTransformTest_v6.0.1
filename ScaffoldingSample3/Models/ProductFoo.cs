using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample3.Models
{ // Comment
    [Table("Product")]
    public partial class ProductFoo : EntityBase // My Handlebars Helper
    {
        public ProductFoo()
        {
            OrderDetailsFoo = new HashSet<OrderDetailFoo>();
        }

        [Key]
        [Column("ProductId")]
        public int ProductIdFoo { get; set; }
        [Column("ProductName")]
        [StringLength(40)]
        public string ProductNameFoo { get; set; } = null!;
        [Column("CategoryId")]
        public int? CategoryIdFoo { get; set; }
        [Column("UnitPrice", TypeName = "money")]
        public decimal? UnitPriceFoo { get; set; }
        [Column("Discontinued")]
        public bool DiscontinuedFoo { get; set; }
        [Column("RowVersion")]
        public byte[]? RowVersionFoo { get; set; }

        [ForeignKey(nameof(CategoryIdFoo))]
        [InverseProperty("ProductsFoo")]
        public virtual CategoryFoo? CategoryFoo { get; set; }
        [InverseProperty(nameof(OrderDetailFoo.ProductFoo))]
        public virtual ICollection<OrderDetailFoo> OrderDetailsFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
