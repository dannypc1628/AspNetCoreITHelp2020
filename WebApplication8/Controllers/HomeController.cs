using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AspCoreIThelp2020Context _context;

        public HomeController(ILogger<HomeController> logger,AspCoreIThelp2020Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(HomeViewModel data)
        {
            ViewBag.myName = data.Name;
            ViewBag.age = data.Age;
            var model = new HomeViewModel() { Name = data.Name, Age = data.Age };
            return View(model);
        }

        public IActionResult Privacy()
        {

            //AdoNetDBModel db = new AdoNetDBModel();
            //var dataList = db.Get();
            var data = _context.Product.Where(d=>d.Price>20000).ToList();

            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
