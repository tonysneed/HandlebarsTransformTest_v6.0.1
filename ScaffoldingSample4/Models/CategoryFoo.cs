using System;
using System.Collections.Generic; // Comment

namespace ScaffoldingSample.Models
{ // Comment
    public partial class CategoryFoo : EntityBase // My Handlebars Helper
    {
        public CategoryFoo()
        {
            ProductsFoo = new HashSet<ProductFoo>();
        }

        public int CategoryIdFoo { get; set; }
        public string CategoryNameFoo { get; set; } = null!;

        public virtual ICollection<ProductFoo> ProductsFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
