using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vision.Controllers
{
    public class PriceSectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}