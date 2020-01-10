using System;
using System.Collections.Generic;

namespace IsadMholt.Models
{
    public partial class ItemsOrdered
    {
        public int IdOrder { get; set; }
        public int IdItem { get; set; }
        public int Quantity { get; set; }
    }
}
