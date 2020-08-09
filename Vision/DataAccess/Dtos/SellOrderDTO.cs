using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Dtos
{
    public class SellOrderDTO
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
        public int BuyOrderId { get; set; }

        public SellOrder MapToModel()
        {
            SellOrder model = new SellOrder()
            {
                Id = this.Id,
                OrderNumber = this.OrderNumber,
                Date = this.Date,
                Symbol = this.Symbol,
                Volume = this.Volume,
                Price = this.Price,
                TradingFee = this.TradingFee,
                Time = this.Time,
                Note = this.Note,
                Tax = this.Tax,
                Value = this.Value,
                BuyOrderId = this.BuyOrderId
            };

            return model;
        }
    }
}
