using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Services.LogicServices;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Vision.Controllers
{
    public class AutoJobController : Controller
    {
        private readonly IUpdateTDaysService _updateTDaysService;

        public AutoJobController(IUpdateTDaysService updateTDaysService)
        {
            _updateTDaysService = updateTDaysService;
        }

        public IActionResult Index()
        {
            RecurringJob.AddOrUpdate(() => _updateTDaysService.Update() , "*/1 * * * *", TimeZoneInfo.Local);

            return RedirectToAction("", "Hangfire");
        }
    }
}