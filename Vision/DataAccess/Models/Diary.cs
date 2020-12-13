using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Diary
    {
        public int Id { get; set; }
        public DateTime RecordTime { get; set; }
        public double AdditionAmount { get; set; }
        public double OpeningBalance { get; set; }
        public double EndingBalance { get; set; }
        public double Interest { get; set; }
        public double InterestPercent { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
    }
}
