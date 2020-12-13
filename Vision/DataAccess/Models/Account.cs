using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Company { get; set; }
        public double Balance { get; set; }
        public double StockValue { get; set; }
        public int UserId { get; set; }
    }
}
