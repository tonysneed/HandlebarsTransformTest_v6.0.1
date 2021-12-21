using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NoTemplates_Annotations.Models
{
    [Table("Employee")]
    public partial class Employee
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

        [ForeignKey("EmployeeId")]
        [InverseProperty(nameof(Territory.Employees))]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
