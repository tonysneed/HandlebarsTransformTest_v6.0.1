using System;
using System.Collections.Generic; // Comment

namespace ScaffoldingSample4.Models
{ // Comment
    public partial class OrderFoo : EntityBase // My Handlebars Helper
    {
        public OrderFoo()
        {
            OrderDetailsFoo = new HashSet<OrderDetailFoo>();
        }

        public int OrderIdFoo { get; set; }
        public string? CustomerIdFoo { get; set; }
        public DateTime? OrderDateFoo { get; set; }
        public DateTime? ShippedDateFoo { get; set; }
        public int? ShipViaFoo { get; set; }
        public decimal? FreightFoo { get; set; }

        public virtual CustomerFoo? CustomerFoo { get; set; }
        public virtual ICollection<OrderDetailFoo> OrderDetailsFoo { get; set; }

        // My Handlebars Block Helper: True
        // My Handlebars Block Helper: False
    }
}
