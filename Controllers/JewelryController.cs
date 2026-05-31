using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JewelryStore.Models;

namespace Kuzmich_JewelryStore.Controllers
{
    public class JewelryController : Controller
    {
        private JewelryContext db = new JewelryContext();

        // GET: Jewelry
        public ActionResult Index()
        {
            var jewelries = db.Jewelries.Include(j => j.Category);
            return View(jewelries.ToList());
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