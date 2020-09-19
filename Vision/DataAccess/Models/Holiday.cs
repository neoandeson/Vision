using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Holiday
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
    }
}
