using DataService.Models;
using DataService.Utilities;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace DataService.Services.ImportExcelServices
{
    public interface IImportOrderFromExcelVNDService
    {
        ServiceResponse<bool> Import(FileStream fs);
    }

    public class ImportOrderFromExcelVNDService : IImportOrderFromExcelVNDService
    {
        private readonly VisionContext _dbContext;

        public ImportOrderFromExcelVNDService(VisionContext dbContext)
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
                        Order order = new Order
                        {
                            UserId = 0,

                            MatchTime = DateTime.ParseExact(
                                reader.GetValue(1).ToString().Substring(0, 10) 
                                + reader.GetValue(12).ToString().Substring(10, 8), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                            OrderNumber = reader.GetDouble(0).ToString(),
                            AccountId = 111,//TODO
                            Type = CommonFunction.GetOrderType(reader.GetString(3)),

                            SymbolName = reader.GetValue(2).ToString(),
                            SymbolId = 0,

                            Quantity = (int)reader.GetDouble(7),
                            Price = reader.GetDouble(8),
                            Fee = reader.GetDouble(10),

                            Note = reader.GetString(11)
                        };
                        order.CalculateTax();

                        orders.Add(order);
                    }

                    _dbContext.Order.AddRange(orders);
                    _dbContext.SaveChanges();

                    response = new ServiceResponse<bool>()
                    {
                        IsSuccess = true,
                        Message = Constants.ResponseMessage.ImportOrderFromExcel_VND_Sucess,
                    };
                }
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<bool>()
                {
                    IsSuccess = false,
                    Message = Constants.ResponseMessage.ImportOrderFromExcel_VND_Fail,
                };
            }

            return response;
        }
    }
}
