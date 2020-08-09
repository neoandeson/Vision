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
                CurrentValue = this.CurrentValue,
                Department = this.Department,
                Description = this.Description,
                Note = this.Note,
                Symbol = this.Symbol,
                TotalBuy = this.TotalBuy,
                TotalSell = this.TotalSell,
                Type = this.Type,
                UserId = this.UserId
            };

            return dto;
        }

        public void UpdateFieldFromDTO(AccountStateDTO dto)
        {
            this.CurrentValue = dto.CurrentValue;
            this.Department = dto.Department;
            this.Description = dto.Description;
            this.Note = dto.Note;
            this.Symbol = dto.Symbol;
            this.TotalBuy = dto.TotalBuy;
            this.TotalSell = dto.TotalSell;
            this.Type = dto.Type;
            this.UserId = dto.UserId;
        }
    }
}
