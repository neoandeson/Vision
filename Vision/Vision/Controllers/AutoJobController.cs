﻿using System;
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
            RecurringJob.AddOrUpdate(() => _updateTDaysService.Update() , "* 6 * * *", TimeZoneInfo.Local);

            return RedirectToAction("", "Hangfire");
        }

        [HttpPost]
        public IActionResult UpdateManual()
        {
            _updateTDaysService.Update();

            return Ok("Update TDate success");
        }

        [HttpPost]
        public IActionResult UpdateAuto()
        {
            _updateTDaysService.Update();

            return Ok("Update TDate success");
        }
    }
}