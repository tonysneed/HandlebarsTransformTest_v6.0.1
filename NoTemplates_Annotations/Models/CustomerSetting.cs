using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NoTemplates_Annotations.Models
{
    [Table("CustomerSetting")]
    public partial class CustomerSetting
    {
        [Key]
        [StringLength(5)]
        public string CustomerId { get; set; } = null!;
        [StringLength(50)]
        public string Setting { get; set; } = null!;

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerSetting")]
        public virtual Customer Customer { get; set; } = null!;
    }
}
