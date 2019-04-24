using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using office.life.Models;

namespace office.life.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return $"Спасибо, {order.User}, за покупку!";
        }
        [ActionName("Welcome")]
        public string Hello(string name)
        {
            return $"Hello, {name}";
        }

        public IActionResult Itp()
        {
            return Redirect("http://itp-it.com");
        }
    }
}
