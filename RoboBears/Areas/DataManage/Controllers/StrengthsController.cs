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
    public class StrengthsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Strengths
        public ActionResult Index()
        {
            return View(db.Strengths.ToList());
        }

        // GET: DataManage/Strengths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strength strength = db.Strengths.Find(id);
            if (strength == null)
            {
                return HttpNotFound();
            }
            return View(strength);
        }

        // GET: DataManage/Strengths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataManage/Strengths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StrengthId,Name,DescriptionId")] Strength strength)
        {
            if (ModelState.IsValid)
            {
                db.Strengths.Add(strength);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strength);
        }

        // GET: DataManage/Strengths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strength strength = db.Strengths.Find(id);
            if (strength == null)
            {
                return HttpNotFound();
            }
            return View(strength);
        }

        // POST: DataManage/Strengths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StrengthId,Name,DescriptionId")] Strength strength)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strength).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strength);
        }

        // GET: DataManage/Strengths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strength strength = db.Strengths.Find(id);
            if (strength == null)
            {
                return HttpNotFound();
            }
            return View(strength);
        }

        // POST: DataManage/Strengths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strength strength = db.Strengths.Find(id);
            db.Strengths.Remove(strength);
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
