using System;
using System.Collections.Generic; // Comment

namespace ScaffoldingSample.Models.dbo
{ // Comment
    public partial class OrderDetailFoo : EntityBase // My Handlebars Helper
    {
        public int OrderDetailIdFoo { get; set; }
        public int OrderIdFoo { get; set; }
        public int ProductIdFoo { get; set; }
        public decimal UnitPriceFoo { get; set; }
        public short QuantityFoo { get; set; }
        public float DiscountFoo { get; set; }

        public virtual OrderFoo OrderFoo { get; set; } = null!;
        public virtual ProductFoo ProductFoo { get; set; } = null!;

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
