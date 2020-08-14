﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Dtos;
using DataService.Services.ModelServices;
using Microsoft.AspNetCore.Mvc;

namespace Vision.Controllers
{
    public class SellOrderController : Controller
    {
        private readonly ISellOrderService _sellOrderService;

        public SellOrderController(ISellOrderService sellOrderService)
        {
            _sellOrderService = sellOrderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(SellOrderDTO rqDto)
        {
            return Json(_sellOrderService.Create(rqDto));
        }
    }
}
