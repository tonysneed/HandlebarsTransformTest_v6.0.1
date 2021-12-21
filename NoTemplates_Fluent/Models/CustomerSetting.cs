using System;
using System.Collections.Generic;

namespace NoTemplates_Fluent.Models
{
    public partial class CustomerSetting
    {
        public string CustomerId { get; set; } = null!;
        public string Setting { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
