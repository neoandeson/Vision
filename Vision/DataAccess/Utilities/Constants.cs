﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Utilities
{
    public static class Constants
    {
        //TODO: Implement auth
        public static class CurrentUser
        {
            public static int AuthUserID = 0;
        }

        public static class AccountStateStatus
        {
            public static int Active = 1;
            public static int DeActive = 0;
        }

        public static class PriceSectionStatus
        {
            public static int Active = 1;
            public static int DeActive = 0;
        }

        public static class BuyOrderStatus
        {
            public static int Active = 1;
            public static int DeActive = 0;
        }

        public static class SellOrderStatus
        {
            public static int Active = 1;
            public static int DeActive = 0;
        }

        public static class ResponseMessage
        {
            public static string BuyInSuccessfully = "Buy In Successfully";
            public static string SellOutSuccessfully = "Sell Out Successfully";
            public static string UpdateAccountStateSuccessfully = "Update Account State Successfully";
        }
    }
}
