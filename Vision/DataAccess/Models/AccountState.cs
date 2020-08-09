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
        public string CurrentValue { get; set; }
        public string TotalBuy { get; set; }
        public string TotalSell { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }
        public int UserId { get; set; }
    }
}
