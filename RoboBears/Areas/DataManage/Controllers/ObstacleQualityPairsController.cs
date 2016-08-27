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
    public class ObstacleQualityPairsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/ObstacleQualityPairs
        public ActionResult Index()
        {
            return View(db.ObstacleQualityPairs.ToList());
        }

        // GET: DataManage/ObstacleQualityPairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObstacleQualityPair obstacleQualityPair = db.ObstacleQualityPairs.Find(id);
            if (obstacleQualityPair == null)
            {
                return HttpNotFound();
            }
            return View(obstacleQualityPair);
        }

        // GET: DataManage/ObstacleQualityPairs/Create
        public ActionResult Create()
        {
            ViewBag.ObstacleId = new SelectList(db.Obstacles, "ObstacleId", "Title");
            ViewBag.RobotId = new SelectList(db.Robots, "RobotId", "Name");
            return View();
        }

        // POST: DataManage/ObstacleQualityPairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ObstacleQualityPairId,Quality,RobotId,ObstacleId")] ObstacleQualityPair obstacleQualityPair)
        {
            if (ModelState.IsValid)
            {
                db.ObstacleQualityPairs.Add(obstacleQualityPair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObstacleId = new SelectList(db.Obstacles, "ObstacleId", "Title",obstacleQualityPair.ObstacleId);
            ViewBag.RobotId = new SelectList(db.Robots, "RobotId", "Name", obstacleQualityPair.RobotId);
            return View(obstacleQualityPair);
        }

        // GET: DataManage/ObstacleQualityPairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObstacleQualityPair obstacleQualityPair = db.ObstacleQualityPairs.Find(id);
            if (obstacleQualityPair == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObstacleId = new SelectList(db.Obstacles, "ObstacleId", "Title", obstacleQualityPair.ObstacleId);
            ViewBag.RobotId = new SelectList(db.Robots, "RobotId", "Name", obstacleQualityPair.RobotId);
            return View(obstacleQualityPair);
        }

        // POST: DataManage/ObstacleQualityPairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ObstacleQualityPairId,Quality,ObstacleId,RobotId")] ObstacleQualityPair obstacleQualityPair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obstacleQualityPair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObstacleId = new SelectList(db.Obstacles, "ObstacleId", "Title", obstacleQualityPair.ObstacleId);
            ViewBag.RobotId = new SelectList(db.Robots, "RobotId", "Name", obstacleQualityPair.RobotId);
            return View(obstacleQualityPair);
        }

        // GET: DataManage/ObstacleQualityPairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObstacleQualityPair obstacleQualityPair = db.ObstacleQualityPairs.Find(id);
            if (obstacleQualityPair == null)
            {
                return HttpNotFound();
            }
            return View(obstacleQualityPair);
        }

        // POST: DataManage/ObstacleQualityPairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObstacleQualityPair obstacleQualityPair = db.ObstacleQualityPairs.Find(id);
            db.ObstacleQualityPairs.Remove(obstacleQualityPair);
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
