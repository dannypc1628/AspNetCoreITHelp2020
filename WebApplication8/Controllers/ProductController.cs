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

        public IActionResult Index()
        {
            var data = _context.Product.ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var last = _context.Product.OrderByDescending(d => d.Id).FirstOrDefault();
                product.Id = last.Id + 1;
                _context.Product.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult GetProduct(int ID)
        {
            var data = _context.Product.FirstOrDefault(d => d.Id == ID);
            
            return View(data);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int ID)
        {
            var data = _context.Product.FirstOrDefault(d => d.Id == ID);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)//(int ID,string Name,decimal Price)
        {
            var data = _context.Product.FirstOrDefault(d => d.Id == product.Id);

            if (data != null)
            {
                data.Name = product.Name;
                data.Price = product.Price;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var data = _context.Product.FirstOrDefault(d => d.Id == ID);

            return View(data);
        }

        [HttpPost]
        public IActionResult DoDelete(int ID)
        {
            var data = _context.Product.FirstOrDefault(d => d.Id == ID);

            if (data != null)
            {
                _context.Product.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
