using System;
using System.Collections.Generic; // Comment

namespace ScaffoldingSample2.Models.dbo
{ // Comment
    public partial class TerritoryFoo : EntityBase // My Handlebars Helper
    {
        public TerritoryFoo()
        {
            EmployeesFoo = new HashSet<EmployeeFoo>();
        }

        public string TerritoryIdFoo { get; set; } = null!;
        public string TerritoryDescriptionFoo { get; set; } = null!;

        public virtual ICollection<EmployeeFoo> EmployeesFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
