using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Dtos
{
    public class AccountStateDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal? TotalBuy { get; set; }
        public decimal? TotalSell { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalBuyFee { get; set; }
        public decimal? TotalSellFee { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }

        public AccountState MapToModel(int authUserId)
        {
            AccountState model = new AccountState()
            {
                Id = this.Id,
                Symbol = this.Symbol,
                Description = this.Description,
                Note = this.Note,
                CurrentPrice = this.CurrentPrice,
                CurrentValue = this.CurrentValue,
                TotalBuy = this.TotalBuy,
                TotalSell = this.TotalSell,
                TotalBuyFee = this.TotalBuyFee,
                TotalSellFee = this.TotalSellFee,
                TotalTax = this.TotalTax,
                Type = this.Type,
                Department = this.Department,

                UserId = authUserId
            };

            return model;
        }
    }
}
