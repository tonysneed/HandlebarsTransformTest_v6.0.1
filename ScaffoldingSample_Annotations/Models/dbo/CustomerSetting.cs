using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample_Annotations.Models.dbo
{ // Comment
    [Table("CustomerSetting")]
    public partial class CustomerSetting : EntityBase // My Handlebars Helper
    {
        [Key]
        [StringLength(5)]
        public string CustomerId { get; set; } = null!;
        [StringLength(50)]
        public string Setting { get; set; } = null!;

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerSetting")]
        public virtual Customer Customer { get; set; } = null!;

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
