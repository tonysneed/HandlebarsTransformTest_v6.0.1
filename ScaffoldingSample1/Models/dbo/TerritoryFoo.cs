using System;
using System.Collections.Generic; // Comment
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingSample1.Models.dbo
{ // Comment
    [Table("Territory")]
    public partial class TerritoryFoo : EntityBase // My Handlebars Helper
    {
        public TerritoryFoo()
        {
            EmployeesFoo = new HashSet<EmployeeFoo>();
        }

        [Key]
        [Column("TerritoryId")]
        [StringLength(20)]
        public string TerritoryIdFoo { get; set; } = null!;
        [Column("TerritoryDescription")]
        [StringLength(50)]
        public string TerritoryDescriptionFoo { get; set; } = null!;

        [InverseProperty(nameof(EmployeeFoo.TerritoriesFoo))]
        public virtual ICollection<EmployeeFoo> EmployeesFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
