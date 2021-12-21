﻿using System;
using System.Collections.Generic; // Comment

namespace ScaffoldingSample_Fluent.Models.dbo
{ // Comment
    public partial class Employee : EntityBase // My Handlebars Helper
    {
        public Employee()
        {
            Territories = new HashSet<Territory>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? City { get; set; }
        public Country? Country { get; set; } = null!;

        public virtual ICollection<Territory> Territories { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
