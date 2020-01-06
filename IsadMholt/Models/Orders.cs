using System;
using System.Collections.Generic;

namespace IsadMholt
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public string IdCustomer { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
    }
}
