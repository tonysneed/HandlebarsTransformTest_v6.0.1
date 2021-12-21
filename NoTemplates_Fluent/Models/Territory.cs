using System;
using System.Collections.Generic;

namespace NoTemplates_Fluent.Models
{
    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        public string TerritoryId { get; set; } = null!;
        public string TerritoryDescription { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
