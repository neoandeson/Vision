using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataService.Services.ImportExcelServices;
using DataService.Services.ModelServices;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataService.Utilities.Constants;

namespace Vision.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _sellOrderService;
        private readonly IImportOrderFromExcelVPSService _importOrderFromExcelVPSService;
        private readonly IImportOrderFromExcelVNDService _importOrderFromExcelVNDService;
        private readonly int _authUserID = CurrentUser.AuthUserID;
        private readonly IWebHostEnvironment _env;

        public OrderController(IOrderService sellOrderService, IWebHostEnvironment env, IImportOrderFromExcelVPSService importOrderFromExcelVPSService, IImportOrderFromExcelVNDService importOrderFromExcelVNDService)
        {
            _sellOrderService = sellOrderService;
            _importOrderFromExcelVPSService = importOrderFromExcelVPSService;
            _importOrderFromExcelVNDService = importOrderFromExcelVNDService;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportOrderFromExcel(UploadExcelFileModel model)
        {
            if (model == null || model.UploadedFile == null || model.UploadedFile.Length == 0)
                return Content("file not selected");

            if (model.UploadedFile.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    await model.UploadedFile.CopyToAsync(fileStream);
                    fileStream.Position = 0;

                    switch (model.CompanyId)
                    {
                        case 1: //VNDirect
                            _importOrderFromExcelVNDService.Import(fileStream);
                            break;
                        case 2: //VPS 
                            _importOrderFromExcelVPSService.Import(fileStream); 
                            break;
                        case 3: //DNSE 
                            break;
                    }
                }
            }

            return Ok();
        }
    }

    public class UserModel
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class UploadExcelFileModel
    {
        public IFormFile UploadedFile { get; set; }
        public int CompanyId { get; set; }
    }
}