using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Vision.Controllers
{
    public class AutoJobController : Controller
    {
        public IActionResult Index()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Recuring Job"), "*/1 * * * *", TimeZoneInfo.Local);

            return RedirectToAction("", "Hangfire");
        }
    }
}