using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("Employees")]
    public class EmployeeController : Controller
    {
        private readonly IAccountLogic _accountLogic;

        public EmployeeController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
