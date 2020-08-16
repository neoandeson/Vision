using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class SystemConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StringValue { get; set; }
        public double? FloatValue { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
