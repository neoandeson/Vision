using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Dtos;
using DataService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Vision.Controllers
{
    public class BuyOrderController : Controller
    {
        private readonly IBuyOrderService _buyOrderService;
        private readonly IPriceSectionService _priceSectionService;
        private readonly IAccountStateService _accountStateService;

        public BuyOrderController(IBuyOrderService buyOrderService, IPriceSectionService priceSectionService, IAccountStateService accountStateService)
        {
            _buyOrderService = buyOrderService;
            _priceSectionService = priceSectionService;
            _accountStateService = accountStateService;
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
            return Json(_buyOrderService.BuyIn(_priceSectionService, _accountStateService, rqDto));
        }
    }
}
