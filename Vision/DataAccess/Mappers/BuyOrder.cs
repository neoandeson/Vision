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
                OrderNumber = this.OrderNumber,
                Date = this.Date,
                Symbol = this.Symbol,
                Type = this.Type,
                Volume = this.Volume,
                Price = this.Price,
                TradingFee = this.TradingFee,
                Time = this.Time,
                MatchedVol = this.MatchedVol,
                T2 = this.T2,
                T1 = this.T1,
                T0 = this.T0,
                Note = this.Note,
                TimerSellDays = this.TimerSellDays,
                PriceSectionId = this.PriceSectionId,
                Sold = this.Sold,
                IsActive = this.IsActive,
                UserId = this.UserId
            };

            return dto;
        }

        public void UpdateFieldFromDTO(BuyOrderDTO dto)
        {
            this.Id = dto.Id;
            this.OrderNumber = dto.OrderNumber;
            this.Date = dto.Date;
            this.Symbol = dto.Symbol;
            this.Type = dto.Type;
            this.Volume = dto.Volume;
            this.Price = dto.Price;
            this.TradingFee = dto.TradingFee;
            this.Time = dto.Time;
            this.MatchedVol = dto.MatchedVol;
            this.T2 = dto.T2;
            this.T1 = dto.T1;
            this.T0 = dto.T0;
            this.Note = dto.Note;
            this.TimerSellDays = dto.TimerSellDays;
            this.PriceSectionId = dto.PriceSectionId;
            this.Sold = dto.Sold;
            this.IsActive = dto.IsActive;
            this.UserId = dto.UserId;
        }
    }
}
