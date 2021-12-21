using System;
using System.Collections.Generic; // Comment

namespace Transform_Fluent.Models.dbo
{ // Comment
    public partial class EmployeeFoo : EntityBase // My Handlebars Helper
    {
        public EmployeeFoo()
        {
            TerritoriesFoo = new HashSet<TerritoryFoo>();
        }

        public int EmployeeIdFoo { get; set; }
        public string LastNameFoo { get; set; } = null!;
        public string FirstNameFoo { get; set; } = null!;
        public DateTime? BirthDateFoo { get; set; }
        public DateTime? HireDateFoo { get; set; }
        public string? CityFoo { get; set; }
        public string? CountryFoo { get; set; }

        public virtual ICollection<TerritoryFoo> TerritoriesFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
