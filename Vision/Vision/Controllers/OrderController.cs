using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        private readonly int _authUserID = CurrentUser.AuthUserID;
        private readonly IWebHostEnvironment _env;

        public OrderController(IOrderService sellOrderService, IWebHostEnvironment env)
        {
            _sellOrderService = sellOrderService;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportOrderFromExcel(IFormFile file, string companyName)
        {
            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Position = 0;

                    List<UserModel> users = new List<UserModel>();
                    using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                    {
                        while (reader.Read()) //Each row of the file
                        {
                            users.Add(new UserModel { Name = reader.GetValue(0).ToString(), City = reader.GetValue(1).ToString() });
                        }
                    }
                }
            }

            return this.View();
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return _env.WebRootPath + "\\uploads\\" + filename;
        }
    }

    public class UserModel
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}