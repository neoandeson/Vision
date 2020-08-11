using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class PriceSection
    {
        public int Id { get; set; }
        public int AccountStateId { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public int MatchedVol { get; set; }
        public int T2 { get; set; }
        public int T1 { get; set; }
        public int T0 { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
    }
}
