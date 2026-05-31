using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewelryStore.Models;

namespace Kuzmich_JewelryStore.Controllers
{
    public class HomeController : Controller
    {
        // Створюємо контекст даних
        JewelryContext db = new JewelryContext();

        // GET: /Home/
        public ActionResult Index()
        {
            // Отримуємо всі прикраси з бази даних
            IEnumerable<Jewelry> jewelries = db.Jewelries;
            // Передаємо в представлення
            ViewBag.Jewelries = jewelries;
            return View();
        }

        // Увага! Для перегляду форми покупки треба спочатку
        // перейти на головну сторінку: localhost:XXXXX/Home
        // і натиснути "Оформити покупку" навпроти товару
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.JewelryId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Дякуємо, " + purchase.Person + ", за покупку!";
        }
    }
}