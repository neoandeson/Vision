﻿using DataService.Models;
using DataService.Utilities;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace DataService.Services.ImportExcelServices
{
    public interface IImportOrderFromExcelVPSService
    {
        ServiceResponse<bool> Import(FileStream fs);
    }

    public class ImportOrderFromExcelVPSService : IImportOrderFromExcelVPSService
    {
        private readonly VisionContext _dbContext;

        public ImportOrderFromExcelVPSService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<bool> Import(FileStream fs)
        {
            ServiceResponse<bool> response;
            List<Order> orders = new List<Order>();

            try
            {
                using (var reader = ExcelReaderFactory.CreateReader(fs))
                {
                    while (reader.Read()) //Each row of the file
                    {
                        orders.Add(new Order
                        {
                            UserId = 0,

                            MatchTime = DateTime.ParseExact(reader.GetValue(0).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            OrderNumber = reader.GetDouble(1).ToString(),
                            AccountId = (int)reader.GetDouble(2),
                            Type = CommonFunction.GetOrderType(reader.GetString(3)),

                            SymbolName = reader.GetValue(4).ToString(),
                            SymbolId = 0,

                            Quantity = (int)reader.GetDouble(7),
                            Price = reader.GetDouble(8),
                            Fee = reader.GetDouble(10),
                            Tax = reader.GetDouble(11),

                            Note = reader.GetString(14)
                        });
                    }

                    _dbContext.Order.AddRange(orders);
                    _dbContext.SaveChanges();

                    response = new ServiceResponse<bool>()
                    {
                        IsSuccess = true,
                        Message = Constants.ResponseMessage.ImportOrderFromExcel_VPS_Sucess,
                    };
                }
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<bool>()
                {
                    IsSuccess = false,
                    Message = Constants.ResponseMessage.ImportOrderFromExcel_VPS_Fail,
                };
            }

            return response;
        }
    }
}
