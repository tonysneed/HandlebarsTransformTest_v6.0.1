﻿using System;
using System.Collections.Generic;

namespace NoTemplates_Fluent.Models
{
    public partial class Employee
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
        public string? Country { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
