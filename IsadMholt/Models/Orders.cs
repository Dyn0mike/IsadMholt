using System;
using System.Collections.Generic;

namespace IsadMholt.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
    }
}
