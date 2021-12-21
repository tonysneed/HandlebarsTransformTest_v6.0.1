using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transform_Annotations.Models.dbo
{ // Comment
    [Table("CustomerSetting")]
    public partial class CustomerSettingFoo : EntityBase // My Handlebars Helper
    {
        [Key]
        [Column("CustomerId")]
        [StringLength(5)]
        public string CustomerIdFoo { get; set; } = null!;
        [Column("Setting")]
        [StringLength(50)]
        public string SettingFoo { get; set; } = null!;

        [ForeignKey(nameof(CustomerIdFoo))]
        [InverseProperty("CustomerSettingFoo")]
        public virtual CustomerFoo CustomerFoo { get; set; } = null!;

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
