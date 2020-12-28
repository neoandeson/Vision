using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Utilities
{
    public static class CommonFunction
    {
        public static int GetOrderType(string type)
        {
            int result = -1;
            type = type.ToLower();

            switch(type)
            {
                case "mua": result = 1; break;
                case "bán": result = 2; break;
            }

            return result;
        }
    }
}
