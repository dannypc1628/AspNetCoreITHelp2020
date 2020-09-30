using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ProductController : Controller
    {
        private readonly AspCoreIThelp2020Context _context;
        public ProductController(AspCoreIThelp2020Context context)
        {
            _context = context;
        }

        public IActionResult GetProduct(int ID)
        {
            var data = _context.Product.FirstOrDefault(d => d.Id == ID);

            return View(data);
        }
    }
}
