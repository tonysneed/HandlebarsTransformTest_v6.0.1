using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NoTransform_Annotations.Models.dbo
{ // Comment
    [Table("Employee")]
    public partial class Employee : EntityBase // My Handlebars Helper
    {
        public Employee()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [StringLength(20)]
        public string LastName { get; set; } = null!;
        [StringLength(20)]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [StringLength(15)]
        public string? City { get; set; }
        [StringLength(15)]
        public string? Country { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Territory.Employees))]
        public virtual ICollection<Territory> Territories { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
