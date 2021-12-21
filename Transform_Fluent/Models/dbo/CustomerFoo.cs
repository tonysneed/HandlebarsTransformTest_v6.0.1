using System;
using System.Collections.Generic; // Comment

namespace Transform_Fluent.Models.dbo
{ // Comment
    public partial class CustomerFoo : EntityBase // My Handlebars Helper
    {
        public CustomerFoo()
        {
            OrdersFoo = new HashSet<OrderFoo>();
        }

        public string CustomerIdFoo { get; set; } = null!;
        public string CompanyNameFoo { get; set; } = null!;
        public string? ContactNameFoo { get; set; }
        public string? CityFoo { get; set; }
        public string? CountryFoo { get; set; }

        public virtual CustomerSettingFoo CustomerSettingFoo { get; set; } = null!;
        public virtual ICollection<OrderFoo> OrdersFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
