using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Dtos
{
    public class BuyOrderDTO
    {
        public int Id { get; set; }
        public int PriceSectionId { get; set; }
        public string Symbol { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public int InvestType { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public decimal TradingFee { get; set; }
        public int MatchedVol { get; set; }
        public int T2 { get; set; }
        public int T1 { get; set; }
        public int T0 { get; set; }
        public string Note { get; set; }
        public int TimerSellDays { get; set; }
        public int Sold { get; set; }

        public BuyOrder MapToModel(int authUserId)
        {
            BuyOrder model = new BuyOrder()
            {
                Id = this.Id,
                PriceSectionId = this.PriceSectionId,
                Symbol = this.Symbol,
                OrderNumber = this.OrderNumber,
                Date = this.Date,
                Time = this.Time,
                InvestType = this.InvestType,
                Volume = this.Volume,
                Price = this.Price,
                TradingFee = this.TradingFee,
                MatchedVol = this.MatchedVol,
                T2 = this.T2,
                T1 = this.T1,
                T0 = this.T0,
                Note = this.Note,
                TimerSellDays = this.TimerSellDays,
                Sold = this.Sold,

                UserId = authUserId
            };

            return model;
        }
    }
}
