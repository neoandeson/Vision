using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class OrderHis
    {
        public int Id { get; set; }
        public int SymbolId { get; set; }
        public int AccountId { get; set; }
        public string SymbolName { get; set; }
        public DateTime MatchTime { get; set; }
        public string OrderNumber { get; set; }
        public int Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Fee { get; set; }
        public double Tax { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
    }
}
