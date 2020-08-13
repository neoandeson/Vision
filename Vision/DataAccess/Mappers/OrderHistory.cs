using DataService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public partial class OrderHistory
    {
        public OrderHistoryDTO MapToDTO()
        {
            OrderHistoryDTO dto = new OrderHistoryDTO()
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
                Revenue = this.Revenue
            };

            return dto;
        }

        public void UpdateFieldFromDTO(OrderHistoryDTO dto)
        {
            this.Id = dto.Id;
            this.PriceSectionId = dto.PriceSectionId;
            this.SellOrderId = dto.SellOrderId;
            this.Symbol = dto.Symbol;
            this.BuyPrice = dto.BuyPrice;
            this.SellPrice = dto.SellPrice;
            this.Volume = dto.Volume;
            this.Margin = dto.Margin;
            this.BuyTradingFee = dto.BuyTradingFee;
            this.SellTradingFee = dto.SellTradingFee;
            this.SellTax = dto.SellTax;
            this.TotalFee = dto.TotalFee;
            this.Revenue = dto.Revenue;
        }
    }
}
