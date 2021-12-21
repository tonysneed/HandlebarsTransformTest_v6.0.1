using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NoTransform_Annotations.Models.dbo
{ // Comment
    [Table("Territory")]
    public partial class Territory : EntityBase // My Handlebars Helper
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [StringLength(20)]
        public string TerritoryId { get; set; } = null!;
        [StringLength(50)]
        public string TerritoryDescription { get; set; } = null!;

        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(Employee.Territories))]
        public virtual ICollection<Employee> Employees { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
