using System;
using System.Collections.Generic;

namespace IsadMholt.Models
{
    public partial class ItemsOrdered
    {
        public int IdOrder { get; set; }
        public string IdItem { get; set; }
        public string Quantity { get; set; }
    }
}
