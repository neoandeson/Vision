using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Dtos
{
    public class PriceSectionDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public int AccountStateId { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public int MatchedVol { get; set; }
        public int T2 { get; set; }
        public int T1 { get; set; }
        public int T0 { get; set; }
        public string Note { get; set; }

        public PriceSection MapToModel(int authUserId)
        {
            PriceSection model = new PriceSection()
            {
                Id = this.Id,
                Symbol = this.Symbol,
                AccountStateId = this.AccountStateId,
                Price = this.Price,
                Volume = this.Volume,
                MatchedVol = this.MatchedVol,
                T2 = this.T2,
                T1 = this.T1,
                T0 = this.T0,
                Note = this.Note,

                UserId = authUserId
            };

            return model;
        }
    }
}
