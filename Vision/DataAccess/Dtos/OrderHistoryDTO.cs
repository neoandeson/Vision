using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Dtos
{
    public class OrderHistoryDTO
    {
        public int Id { get; set; }
        public int PriceSectionId { get; set; }
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

        public OrderHistory MapToModel(int authUserId)
        {
            OrderHistory model = new OrderHistory()
            {
                Id = this.Id,
                PriceSectionId = this.PriceSectionId,
                SellOrderId = this.SellOrderId,
                Symbol = this.Symbol,
                BuyPrice = this.BuyPrice,
                SellPrice = this.SellPrice,
                Volume = this.Volume,
                Margin = this.Margin,
                BuyTradingFee = this.BuyTradingFee,
                SellTradingFee = this.SellTradingFee,
                SellTax = this.SellTax,
                TotalFee = this.TotalFee,
                Revenue = this.Revenue,

                UserId = authUserId
            };

            return model;
        }
    }
}
