using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class SellOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public decimal TradingFee { get; set; }
        public decimal Tax { get; set; }
        public decimal Value { get; set; }
        public int Time { get; set; }
        public string Note { get; set; }
        public int PriceSessionId { get; set; }
        public int BuyOrderId { get; set; }
    }
}
