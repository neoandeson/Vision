using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class OrderHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PriceSectionId { get; set; }
        public int BuyOrderId { get; set; }
        public int SellOrderId { get; set; }
        public string Symbol { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Volume { get; set; }
        public decimal Margin { get; set; }
        public decimal BuyTradingFee { get; set; }
        public decimal SellTradingFee { get; set; }
        public decimal SellTax { get; set; }
        public decimal TotalFee { get; set; }
        public decimal Revenue { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
