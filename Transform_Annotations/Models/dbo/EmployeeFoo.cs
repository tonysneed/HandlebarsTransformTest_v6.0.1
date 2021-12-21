using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transform_Annotations.Models.dbo
{ // Comment
    [Table("Employee")]
    public partial class EmployeeFoo : EntityBase // My Handlebars Helper
    {
        public EmployeeFoo()
        {
            TerritoriesFoo = new HashSet<TerritoryFoo>();
        }

        [Key]
        [Column("EmployeeId")]
        public int EmployeeIdFoo { get; set; }
        [Column("LastName")]
        [StringLength(20)]
        public string LastNameFoo { get; set; } = null!;
        [Column("FirstName")]
        [StringLength(20)]
        public string FirstNameFoo { get; set; } = null!;
        [Column("BirthDate", TypeName = "datetime")]
        public DateTime? BirthDateFoo { get; set; }
        [Column("HireDate", TypeName = "datetime")]
        public DateTime? HireDateFoo { get; set; }
        [Column("City")]
        [StringLength(15)]
        public string? CityFoo { get; set; }
        [Column("Country")]
        [StringLength(15)]
        public string? CountryFoo { get; set; }

        [InverseProperty(nameof(TerritoryFoo.EmployeesFoo))]
        public virtual ICollection<TerritoryFoo> TerritoriesFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
