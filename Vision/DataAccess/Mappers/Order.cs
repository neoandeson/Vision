using DataService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using static DataService.Utilities.Constants;

namespace DataService.Models
{
    public partial class Order
    {
        public void CalculateTax()
        {
            if(this.Type == OrderType.Sell)
            {
                this.Tax = (this.Quantity * this.Price) * 0.0001;
            }
        }

        public OrderDTO MapToDTO()
        {
            OrderDTO dto = new OrderDTO()
            {
                Id = this.Id,
                SymbolId = this.SymbolId,
                AccountId = this.AccountId,
                SymbolName = this.SymbolName,
                MatchTime = this.MatchTime,
                OrderNumber = this.OrderNumber,
                Type = this.Type,
                Quantity = this.Quantity,
                Price = this.Price,
                Fee = this.Fee,
                Tax = this.Tax,
                Note = this.Note
            };

            return dto;
        }

        public void UpdateFieldFromDTO(OrderDTO dto)
        {
            this.Id = dto.Id;
            this.SymbolId = dto.SymbolId;
            this.AccountId = dto.AccountId;
            this.SymbolName = dto.SymbolName;
            this.MatchTime = dto.MatchTime;
            this.OrderNumber = dto.OrderNumber;
            this.Type = dto.Type;
            this.Quantity = dto.Quantity;
            this.Price = dto.Price;
            this.Fee = dto.Fee;
            this.Tax = dto.Tax;
            this.Note = dto.Note;
        }
    }
}
