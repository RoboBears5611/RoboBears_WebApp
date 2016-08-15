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
    public class CompetitionsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Competitions
        public ActionResult Index()
        {
            var competitions = db.Competitions.Include(c => c.CompetitionType).Include(c => c.year);
            return View(competitions.ToList());
        }

        // GET: DataManage/Competitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // GET: DataManage/Competitions/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionTypeId = new SelectList(db.CompetitionTypes, "CompetitionTypeId", "Title");
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId");
            return View();
        }

        // POST: DataManage/Competitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitionID,Title,Location,Lat,Lng,Date,CompetitionTypeId,DescriptionId,YearId")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competitions.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionTypeId = new SelectList(db.CompetitionTypes, "CompetitionTypeId", "Title", competition.CompetitionTypeId);
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId", competition.YearId);
            return View(competition);
        }

        // GET: DataManage/Competitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionTypeId = new SelectList(db.CompetitionTypes, "CompetitionTypeId", "Title", competition.CompetitionTypeId);
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId", competition.YearId);
            return View(competition);
        }

        // POST: DataManage/Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetitionID,Title,Location,Lat,Lng,Date,CompetitionTypeId,DescriptionId,YearId")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionTypeId = new SelectList(db.CompetitionTypes, "CompetitionTypeId", "Title", competition.CompetitionTypeId);
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearId", competition.YearId);
            return View(competition);
        }

        // GET: DataManage/Competitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: DataManage/Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competitions.Find(id);
            db.Competitions.Remove(competition);
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
