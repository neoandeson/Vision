using DataService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public partial class SellOrder
    {
        public SellOrderDTO MapToDTO()
        {
            SellOrderDTO dto = new SellOrderDTO()
            {
                Id = this.Id,
                OrderNumber = this.OrderNumber,
                Date = this.Date,
                Symbol = this.Symbol,
                Volume = this.Volume,
                Price = this.Price,
                TradingFee = this.TradingFee,
                Tax = this.Tax,
                Value = this.Value,
                Time = this.Time,
                Note = this.Note
            };

            return dto;
        }

        public void UpdateFieldFromDTO(SellOrderDTO dto)
        {
            this.Id = dto.Id;
            this.OrderNumber = dto.OrderNumber;
            this.Date = dto.Date;
            this.Symbol = dto.Symbol;
            this.Volume = dto.Volume;
            this.Price = dto.Price;
            this.TradingFee = dto.TradingFee;
            this.Tax = dto.Tax;
            this.Value = dto.Value;
            this.Time = dto.Time;
            this.Note = dto.Note;
        }
    }
}
