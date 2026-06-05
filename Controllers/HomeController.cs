using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewelryStore.Models;
using Kuzmich_JewelryStore.Filters;
using System.Data.Entity;

namespace Kuzmich_JewelryStore.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        JewelryContext db = new JewelryContext();

        // GET: /Home/
        public ActionResult Index()
        {
            IEnumerable<Jewelry> jewelries = db.Jewelries;
            ViewBag.Jewelries = jewelries;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Jewelry");
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

        [HttpPost]
        public ActionResult JewelrySearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return PartialView("_JewelrySearchResult", new List<JewelryStore.Models.Jewelry>());

            var results = db.Jewelries
                .Include("Category")
                .Where(j => j.Name.Contains(query) || j.Material.Contains(query))
                .ToList();

            return PartialView("_JewelrySearchResult", results);
        }

        // Зміна мови через кукі
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer != null
                ? Request.UrlReferrer.AbsolutePath
                : "/";

            List<string> cultures = new List<string>() { "ua", "en", "de" };
            if (!cultures.Contains(lang))
            {
                lang = "ua";
            }

            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}