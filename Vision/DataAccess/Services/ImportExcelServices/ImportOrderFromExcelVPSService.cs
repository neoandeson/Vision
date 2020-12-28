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
            List<OrderHis> orderHis = new List<OrderHis>();
            bool reachHeader = false;

            try
            {
                using (var reader = ExcelReaderFactory.CreateBinaryReader(fs))
                {
                    while (reader.Read()) //Each row of the file
                    {
                        if (reader.GetString(1) == "Thời gian")
                        {
                            reachHeader = true;
                        }

                        if (reachHeader)
                        {
                            orderHis.Add(new OrderHis
                            {
                                UserId = 0,

                                MatchTime = DateTime.ParseExact(reader.GetValue(0).ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                                OrderNumber = reader.GetString(1),
                                AccountId = reader.GetInt16(2),
                                Type = CommonFunction.GetOrderType(reader.GetString(3)),

                                SymbolName = reader.GetValue(4).ToString(),
                                SymbolId = 0,

                                Quantity = reader.GetInt16(7),
                                Price = reader.GetDouble(8),
                                Fee = reader.GetDouble(10),
                                Tax = reader.GetDouble(11),

                                Note = reader.GetString(14)
                            });
                        }
                    }

                    _dbContext.OrderHis.AddRange(orderHis);
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
