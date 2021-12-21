using System;
using System.Collections.Generic; // Comment

namespace Transform_Fluent.Models.dbo
{ // Comment
    public partial class ProductFoo : EntityBase // My Handlebars Helper
    {
        public ProductFoo()
        {
            OrderDetailsFoo = new HashSet<OrderDetailFoo>();
        }

        public int ProductIdFoo { get; set; }
        public string ProductNameFoo { get; set; } = null!;
        public int? CategoryIdFoo { get; set; }
        public decimal? UnitPriceFoo { get; set; }
        public bool DiscontinuedFoo { get; set; }
        public byte[]? RowVersionFoo { get; set; }

        public virtual CategoryFoo? CategoryFoo { get; set; }
        public virtual ICollection<OrderDetailFoo> OrderDetailsFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
