using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample3.Models
{ // Comment
    [Table("Category")]
    public partial class CategoryFoo : EntityBase // My Handlebars Helper
    {
        public CategoryFoo()
        {
            ProductsFoo = new HashSet<ProductFoo>();
        }

        [Key]
        [Column("CategoryId")]
        public int CategoryIdFoo { get; set; }
        [Column("CategoryName")]
        [StringLength(15)]
        public string CategoryNameFoo { get; set; } = null!;

        [InverseProperty(nameof(ProductFoo.CategoryFoo))]
        public virtual ICollection<ProductFoo> ProductsFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
