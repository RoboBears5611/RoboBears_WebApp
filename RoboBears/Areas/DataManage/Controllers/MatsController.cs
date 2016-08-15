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
    public class MatsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Mats
        public ActionResult Index()
        {
            var mats = db.Mats.Include(m => m.Game);
            return View(mats.ToList());
        }

        // GET: DataManage/Mats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mat mat = db.Mats.Find(id);
            if (mat == null)
            {
                return HttpNotFound();
            }
            return View(mat);
        }

        // GET: DataManage/Mats/Create
        public ActionResult Create()
        {
            ViewBag.MatId = new SelectList(db.Games, "GameId", "Title");
            return View();
        }

        // POST: DataManage/Mats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatId,DescriptionId")] Mat mat)
        {
            if (ModelState.IsValid)
            {
                db.Mats.Add(mat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatId = new SelectList(db.Games, "GameId", "Title", mat.MatId);
            return View(mat);
        }

        // GET: DataManage/Mats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mat mat = db.Mats.Find(id);
            if (mat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatId = new SelectList(db.Games, "GameId", "Title", mat.MatId);
            return View(mat);
        }

        // POST: DataManage/Mats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatId,DescriptionId")] Mat mat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatId = new SelectList(db.Games, "GameId", "Title", mat.MatId);
            return View(mat);
        }

        // GET: DataManage/Mats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mat mat = db.Mats.Find(id);
            if (mat == null)
            {
                return HttpNotFound();
            }
            return View(mat);
        }

        // POST: DataManage/Mats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mat mat = db.Mats.Find(id);
            db.Mats.Remove(mat);
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
