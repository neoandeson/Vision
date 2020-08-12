using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class AccountState
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal TotalBuy { get; set; }
        public decimal TotalSell { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }
        public int UserId { get; set; }
    }
}
