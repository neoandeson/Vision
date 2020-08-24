using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Dtos;
using DataService.Services.LogicServices;
using DataService.Services.ModelServices;
using DataService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static DataService.Utilities.Constants;

namespace Vision.Controllers
{
    public class SellOrderController : Controller
    {
        private readonly ISellOrderService _sellOrderService;
        private readonly ISellOutService _sellOutService;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public SellOrderController(ISellOrderService sellOrderService, ISellOutService sellOutService)
        {
            _sellOrderService = sellOrderService;
            _sellOutService = sellOutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SellOut(SellOrderDTO sellOrderDTO, SellOutViewModel[] arrSelectedPS)
        {
            _sellOutService.SellOut(sellOrderDTO, arrSelectedPS, _authUserID);

            return Json("");
        }
    }
}
