using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Dtos;
using DataService.Services.ModelServices;
using Microsoft.AspNetCore.Mvc;

namespace Vision.Controllers
{
    public class AccountStateController : Controller
    {
        private readonly IAccountStateService _accountStateService;

        public AccountStateController(IAccountStateService accountStateService)
        {
            _accountStateService = accountStateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_accountStateService.GetAll());
        }

        public IActionResult GetById(int id)
        {
            return Json(_accountStateService.Get(id));
        }

        public IActionResult Update(AccountStateDTO accountStateDTO)
        {
            return Json(_accountStateService.Update(accountStateDTO));
        }
    }
}