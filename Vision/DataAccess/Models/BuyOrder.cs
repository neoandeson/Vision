using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class BuyOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public int Type { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public decimal TradingFee { get; set; }
        public int Time { get; set; }
        public int T2 { get; set; }
        public int T1 { get; set; }
        public int T0 { get; set; }
        public string Note { get; set; }
        public int TimerSellDays { get; set; }
        public int PriceSectionId { get; set; }
        public int Sold { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
