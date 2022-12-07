using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTestAppBank.Controllers
{
    public class ErrorsController : Controller
    {
        [HttpGet]
        public IActionResult NotFoundBanknotesError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WithdrawalError()
        {
            return View();
        }
    }
}
