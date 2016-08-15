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
    public class CompetitionTypesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/CompetitionTypes
        public ActionResult Index()
        {
            return View(db.CompetitionTypes.ToList());
        }

        // GET: DataManage/CompetitionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionType competitionType = db.CompetitionTypes.Find(id);
            if (competitionType == null)
            {
                return HttpNotFound();
            }
            return View(competitionType);
        }

        // GET: DataManage/CompetitionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataManage/CompetitionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitionTypeId,Title,Level")] CompetitionType competitionType)
        {
            if (ModelState.IsValid)
            {
                db.CompetitionTypes.Add(competitionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competitionType);
        }

        // GET: DataManage/CompetitionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionType competitionType = db.CompetitionTypes.Find(id);
            if (competitionType == null)
            {
                return HttpNotFound();
            }
            return View(competitionType);
        }

        // POST: DataManage/CompetitionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetitionTypeId,Title,Level")] CompetitionType competitionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competitionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competitionType);
        }

        // GET: DataManage/CompetitionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionType competitionType = db.CompetitionTypes.Find(id);
            if (competitionType == null)
            {
                return HttpNotFound();
            }
            return View(competitionType);
        }

        // POST: DataManage/CompetitionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetitionType competitionType = db.CompetitionTypes.Find(id);
            db.CompetitionTypes.Remove(competitionType);
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
