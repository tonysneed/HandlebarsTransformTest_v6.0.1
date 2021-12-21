using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NoTransform_Annotations.Models.dbo
{ // Comment
    [Table("Category")]
    public partial class Category : EntityBase // My Handlebars Helper
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }
        [StringLength(15)]
        public string CategoryName { get; set; } = null!;

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
