using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.ViewModels
{
    public class AccountStateViewModel
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }
    }
}
