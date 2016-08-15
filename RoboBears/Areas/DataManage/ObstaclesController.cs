using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoboBears.DatabaseAccessors.EntityFramework;

namespace RoboBears.Areas.DataManage
{
    public class ObstaclesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Obstacles
        public ActionResult Index()
        {
            var obstacles = db.Obstacles.Include(o => o.Mat);
            return View(obstacles.ToList());
        }

        // GET: DataManage/Obstacles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obstacle obstacle = db.Obstacles.Find(id);
            if (obstacle == null)
            {
                return HttpNotFound();
            }
            return View(obstacle);
        }

        // GET: DataManage/Obstacles/Create
        public ActionResult Create()
        {
            ViewBag.MatId = new SelectList(db.Mats, "MatId", "MatId");
            return View();
        }

        // POST: DataManage/Obstacles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ObstacleId,Title,Hieght,Width,Length,DescriptionId,MatId")] Obstacle obstacle)
        {
            if (ModelState.IsValid)
            {
                db.Obstacles.Add(obstacle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatId = new SelectList(db.Mats, "MatId", "MatId", obstacle.MatId);
            return View(obstacle);
        }

        // GET: DataManage/Obstacles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obstacle obstacle = db.Obstacles.Find(id);
            if (obstacle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatId = new SelectList(db.Mats, "MatId", "MatId", obstacle.MatId);
            return View(obstacle);
        }

        // POST: DataManage/Obstacles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ObstacleId,Title,Hieght,Width,Length,DescriptionId,MatId")] Obstacle obstacle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obstacle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatId = new SelectList(db.Mats, "MatId", "MatId", obstacle.MatId);
            return View(obstacle);
        }

        // GET: DataManage/Obstacles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obstacle obstacle = db.Obstacles.Find(id);
            if (obstacle == null)
            {
                return HttpNotFound();
            }
            return View(obstacle);
        }

        // POST: DataManage/Obstacles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obstacle obstacle = db.Obstacles.Find(id);
            db.Obstacles.Remove(obstacle);
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
