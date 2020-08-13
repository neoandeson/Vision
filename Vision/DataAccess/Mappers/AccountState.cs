using DataService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public partial class AccountState
    {
        public AccountStateDTO MapToDTO()
        {
            AccountStateDTO dto = new AccountStateDTO()
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
                Department = this.Department
            };

            return dto;
        }

        public void UpdateFieldFromDTO(AccountStateDTO dto, int authUserId)
        {
            Id = this.Id;
            Symbol = this.Symbol;
            Description = this.Description;
            Note = this.Note;
            CurrentPrice = this.CurrentPrice;
            CurrentValue = this.CurrentValue;
            TotalBuy = this.TotalBuy;
            TotalSell = this.TotalSell;
            TotalBuyFee = this.TotalBuyFee;
            TotalSellFee = this.TotalSellFee;
            TotalTax = this.TotalTax;
            Type = this.Type;
            Department = this.Department;

            UserId = authUserId;
        }
    }
}
