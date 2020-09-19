using DataService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public partial class BuyOrder
    {
        public BuyOrderDTO MapToDTO()
        {
            BuyOrderDTO dto = new BuyOrderDTO()
            {
                Id = this.Id,
                PriceSectionId = this.PriceSectionId,
                Symbol = this.Symbol,
                OrderNumber = this.OrderNumber,
                Date = this.Date,
                BuyDate = this.BuyDate,
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
                Sold = this.Sold
            };

            return dto;
        }

        public void UpdateFieldFromDTO(BuyOrderDTO dto)
        {
            this.Id = dto.Id;
            this.PriceSectionId = dto.PriceSectionId;
            this.Symbol = dto.Symbol;
            this.OrderNumber = dto.OrderNumber;
            this.Date = dto.Date;
            this.Time = dto.Time;
            this.InvestType = dto.InvestType;
            this.Volume = dto.Volume;
            this.Price = dto.Price;
            this.TradingFee = dto.TradingFee;
            this.MatchedVol = dto.MatchedVol;
            this.T2 = dto.T2;
            this.T1 = dto.T1;
            this.T0 = dto.T0;
            this.Note = dto.Note;
            this.TimerSellDays = dto.TimerSellDays;
            this.Sold = dto.Sold;
        }
    }
}
