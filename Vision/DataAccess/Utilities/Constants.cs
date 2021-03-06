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

        public static class OrderType
        {
            public static int Buy = 1;
            public static int Sell = 2;
        }

        public static class ResponseMessage
        {
            public static string BuyInSuccessfully = "Buy In Successfully";
            public static string SellOutSuccessfully = "Sell Out Successfully";
            public static string UpdateAccountStateSuccessfully = "Update Account State Successfully";

            public static string ImportOrderFromExcel_VPS_Sucess = "Import order history from VPS excel successfully";
            public static string ImportOrderFromExcel_VPS_Fail = "Import order history from VPS excel fail";

            public static string ImportOrderFromExcel_VND_Sucess = "Import order history from VND excel successfully";
            public static string ImportOrderFromExcel_VND_Fail = "Import order history from VND excel fail";
        }
    }
}
