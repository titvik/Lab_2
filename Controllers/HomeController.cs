using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab2.Models;

namespace lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        // Manual With Single Action
        public IActionResult InSingleAction()
        {
            
            if(this.Request.Method == "GET")
            {
                return View();
            }
            else if(this.Request.Method == "POST")
            {
                CalcModel calc = new CalcModel(Int32.Parse(HttpContext.Request.Form["first-value"]), HttpContext.Request.Form["op"], Int32.Parse(HttpContext.Request.Form["second-value"]));
              
                return View("Result", calc);
            }
            return View();
        }


        // Manual With Separate Handlers
        [HttpGet]
        public IActionResult InSeparateActions()
        {

            return View();
        }

        [HttpPost]
        public IActionResult InSeparateActions(string id)
        {
            CalcModel calc = new CalcModel(Int32.Parse(HttpContext.Request.Form["first-value"]), HttpContext.Request.Form["op"], Int32.Parse(HttpContext.Request.Form["second-value"]));
            return View("Result", calc);
        }


        // Model Binding In Parameters
        [HttpGet]
        public IActionResult MBwithParameters()
        {

            return View();
        }

        [HttpPost]
        public IActionResult MBwithParameters([Bind("FirstValue, Op, SecondValue")] CalcModel calc)
        {
            calc.Calculate();
            return View("Result", calc);
        }
    
        // Model Binding In Separate Model
        [HttpGet]
        public IActionResult MBwithSeparateModel()
        {

            return View();
        }

        [HttpPost]
        public IActionResult MBwithSeparateModel(CalcModel calc)
        {
            calc.Calculate();
            return View("Result", calc);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
