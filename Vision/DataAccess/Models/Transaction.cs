using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public DateTime RecordTime { get; set; }
        public double Amount { get; set; }
        public int AccountId { get; set; }
        public string Note { get; set; }
        public int? OrderNumber { get; set; }
        public int UserId { get; set; }
    }
}
