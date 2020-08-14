using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Dtos;
using DataService.Services;
using DataService.Services.LogicServices;
using DataService.Services.ModelServices;
using Microsoft.AspNetCore.Mvc;
using static DataService.Utilities.Constants;

namespace Vision.Controllers
{
    public class BuyOrderController : Controller
    {
        private readonly IBuyOrderService _buyOrderService;
        private readonly IBuyInService _buyInService;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public BuyOrderController(IBuyOrderService buyOrderService, IBuyInService buyInService)
        {
            _buyOrderService = buyOrderService;
            _buyInService = buyInService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllByPriceSectionId(int priceSectionId)
        {
            return Json(_buyOrderService.GetAllByPriceSectionId(priceSectionId));
        }

        public IActionResult BuyIn(BuyOrderDTO rqDto)
        {
            return Json(_buyInService.BuyIn(rqDto, _authUserID));
        }
    }
}
