using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Dtos
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int SymbolId { get; set; }
        public int AccountId { get; set; }
        public string SymbolName { get; set; }
        public DateTime MatchTime { get; set; }
        public string OrderNumber { get; set; }
        public int Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Fee { get; set; }
        public double Tax { get; set; }
        public string Note { get; set; }

        public Order MapToModel(int authUserId)
        {
            Order model = new Order()
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
                Note = this.Note,

                UserId = authUserId
            };

            return model;
        }
    }
}
