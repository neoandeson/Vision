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

        public BuyOrderController(IBuyOrderService buyOrderService)
        {
            _buyOrderService = buyOrderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllByPriceSectionId(int priceSectionId)
        {
            return Json(_buyOrderService.GetAllByPriceSectionId(priceSectionId));
        }

        public IActionResult Create(BuyOrderDTO rqDto)
        {
            return Json(_buyOrderService.Create(rqDto));
        }
    }
}
