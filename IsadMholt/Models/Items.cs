using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace IsadMholt.Models
{
    public partial class Items
    {
        public int IdItem { get; set; }
        public string Catagory { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public decimal? Price { get; set; }
    }
}
