using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoboBears.DatabaseAccessors.EntityFramework;

namespace RoboBears.Areas.DataManage.Controllers
{
    public class YearsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Years
        public ActionResult Index()
        {
            var years = db.Years.Include(y => y.Game);
            return View(years.ToList());
        }

        // GET: DataManage/Years/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // GET: DataManage/Years/Create
        public ActionResult Create()
        {
            ViewBag.YearId = new SelectList(db.Games, "GameId", "Title");
            return View();
        }

        // POST: DataManage/Years/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearId")] Year year)
        {
            if (ModelState.IsValid)
            {
                db.Years.Add(year);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YearId = new SelectList(db.Games, "GameId", "Title", year.YearId);
            return View(year);
        }

        // GET: DataManage/Years/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            ViewBag.YearId = new SelectList(db.Games, "GameId", "Title", year.YearId);
            return View(year);
        }

        // POST: DataManage/Years/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearId")] Year year)
        {
            if (ModelState.IsValid)
            {
                db.Entry(year).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YearId = new SelectList(db.Games, "GameId", "Title", year.YearId);
            return View(year);
        }

        // GET: DataManage/Years/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = db.Years.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // POST: DataManage/Years/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Year year = db.Years.Find(id);
            db.Years.Remove(year);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
