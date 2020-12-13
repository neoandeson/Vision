using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class StockSymbol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
