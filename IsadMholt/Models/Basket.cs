using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsadMholt.Models
{
    public class Basket
    {
        public int IdItem { get; set; }
        public string Catagory { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}
