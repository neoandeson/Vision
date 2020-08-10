using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Vision.Controllers
{
    public class PriceSectionController : Controller
    {
        private readonly IPriceSectionService _priceSectionService;

        public PriceSectionController(IPriceSectionService priceSectionService)
        {
            _priceSectionService = priceSectionService;
        }

        public IActionResult Index(int id)
        {
            ViewData["AccountStateId"] = id;
            return View(id);
        }

        public IActionResult GetAllByAccoutStateId(int accountStateId)
        {
            return Json(_priceSectionService.GetAllByAccountStateId(accountStateId));
        }
    }
}