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
        public string CurrentValue { get; set; }
        public string TotalBuy { get; set; }
        public string TotalSell { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }
        public int UserId { get; set; }

        public AccountState MapToModel()
        {
            AccountState model = new AccountState()
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

            return model;
        }
    }
}
