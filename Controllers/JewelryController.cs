using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JewelryStore.Models;

namespace Kuzmich_JewelryStore.Controllers
{
    [Kuzmich_JewelryStore.Filters.Culture]
    public class JewelryController : Controller
    {
        private JewelryContext db = new JewelryContext();

        // GET: Jewelry
        public ActionResult Index(int? category, string material, int page = 1)
        {
            int pageSize = 3;

            IQueryable<Jewelry> jewelries = db.Jewelries.Include(j => j.Category);

            if (category != null && category != 0)
            {
                jewelries = jewelries.Where(j => j.CategoryId == category);
            }

            if (!String.IsNullOrEmpty(material) && !material.Equals("Всі"))
            {
                jewelries = jewelries.Where(j => j.Material == material);
            }

            int totalItems = jewelries.Count();

            var jewelriesPerPage = jewelries
                .OrderBy(j => j.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            List<Category> categories = db.Categories.ToList();
            categories.Insert(0, new Category { Name = "Всі", Id = 0 });

            JewelryIndexViewModel viewModel = new JewelryIndexViewModel
            {
                Jewelries = jewelriesPerPage,
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = totalItems
                },
                CategoryId = category,
                Material = material
            };

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", category);
            ViewBag.Materials = new SelectList(
                new[] { "Всі" }.Concat(
                    db.Jewelries.Select(j => j.Material).Distinct().ToList()
                ),
                material
            );

            return View(viewModel);
        }

        // GET: Jewelry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Jewelry jewelry = db.Jewelries.Include(j => j.Category)
                                          .FirstOrDefault(j => j.Id == id);
            if (jewelry == null)
                return HttpNotFound();

            return View(jewelry);
        }

        // GET: Jewelry/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Jewelry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Material,Price,CategoryId")] Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {
                db.Jewelries.Add(jewelry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", jewelry.CategoryId);
            return View(jewelry);
        }

        // GET: Jewelry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Jewelry jewelry = db.Jewelries.Find(id);
            if (jewelry == null)
                return HttpNotFound();

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", jewelry.CategoryId);
            return View(jewelry);
        }

        // POST: Jewelry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Material,Price,CategoryId")] Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jewelry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", jewelry.CategoryId);
            return View(jewelry);
        }

        // GET: Jewelry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Jewelry jewelry = db.Jewelries.Include(j => j.Category)
                                          .FirstOrDefault(j => j.Id == id);
            if (jewelry == null)
                return HttpNotFound();

            return View(jewelry);
        }

        // POST: Jewelry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jewelry jewelry = db.Jewelries.Find(id);
            db.Jewelries.Remove(jewelry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}