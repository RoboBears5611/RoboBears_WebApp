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
    public class StrengthQualityPairsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/StrengthQualityPairs
        public ActionResult Index()
        {
            var StrengthQualityPairs = db.StrengthQualityPair.ToList();
            StrengthQualityPairs.ForEach(sqp => sqp.Strength = db.Strengths.Find(sqp.StrengthId));
            return View(StrengthQualityPairs);
        }

        // GET: DataManage/StrengthQualityPairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrengthQualityPair strengthQualityPair = db.StrengthQualityPair.Find(id);
            if (strengthQualityPair == null)
            {
                return HttpNotFound();
            }
            strengthQualityPair.Strength = db.Strengths.Find(strengthQualityPair.StrengthId);
            return View(strengthQualityPair);
        }

        // GET: DataManage/StrengthQualityPairs/Create
        public ActionResult Create()
        {
            ViewBag.StrengthId = new SelectList(db.Strengths, "StrengthId", "Name");
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: DataManage/StrengthQualityPairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StrengthQualityPairId,Quality,StrengthId,TeamId")] StrengthQualityPair strengthQualityPair)
        {
            if (ModelState.IsValid)
            {
                db.StrengthQualityPair.Add(strengthQualityPair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StrengthId = new SelectList(db.Strengths, "StrengthId", "Name", strengthQualityPair.StrengthId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", strengthQualityPair.TeamId);
            return View(strengthQualityPair);
        }

        // GET: DataManage/StrengthQualityPairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrengthQualityPair strengthQualityPair = db.StrengthQualityPair.Find(id);
            if (strengthQualityPair == null)
            {
                return HttpNotFound();
            }
            ViewBag.StrengthId = new SelectList(db.Strengths, "StrengthId", "Name", strengthQualityPair.StrengthId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", strengthQualityPair.TeamId);
            strengthQualityPair.Strength = db.Strengths.Find(strengthQualityPair.StrengthId);
            return View(strengthQualityPair);
        }

        // POST: DataManage/StrengthQualityPairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StrengthQualityPairId,Quality,StrengthId,TeamId")] StrengthQualityPair strengthQualityPair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strengthQualityPair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StrengthId = new SelectList(db.Strengths, "StrengthId", "Name", strengthQualityPair.StrengthId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", strengthQualityPair.TeamId);
            return View(strengthQualityPair);
        }

        // GET: DataManage/StrengthQualityPairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrengthQualityPair strengthQualityPair = db.StrengthQualityPair.Find(id);
            if (strengthQualityPair == null)
            {
                return HttpNotFound();
            }
            ViewBag.StrengthId = new SelectList(db.Strengths, "StrengthId", "Name", strengthQualityPair.StrengthId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", strengthQualityPair.TeamId);
            strengthQualityPair.Strength = db.Strengths.Find(strengthQualityPair.StrengthId);
            return View(strengthQualityPair);
        }

        // POST: DataManage/StrengthQualityPairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StrengthQualityPair strengthQualityPair = db.StrengthQualityPair.Find(id);
            db.StrengthQualityPair.Remove(strengthQualityPair);
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
