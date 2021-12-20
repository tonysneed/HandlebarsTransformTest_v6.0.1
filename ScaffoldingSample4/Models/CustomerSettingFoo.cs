using System;
using System.Collections.Generic; // Comment

namespace ScaffoldingSample4.Models
{ // Comment
    public partial class CustomerSettingFoo : EntityBase // My Handlebars Helper
    {
        public string CustomerIdFoo { get; set; } = null!;
        public string SettingFoo { get; set; } = null!;

        public virtual CustomerFoo CustomerFoo { get; set; } = null!;

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
