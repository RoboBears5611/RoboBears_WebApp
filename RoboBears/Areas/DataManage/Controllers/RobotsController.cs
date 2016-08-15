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
    public class RobotsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Robots
        public ActionResult Index()
        {
            var robots = db.Robots.Include(r => r.Team);
            return View(robots.ToList());
        }

        // GET: DataManage/Robots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Robot robot = db.Robots.Find(id);
            if (robot == null)
            {
                return HttpNotFound();
            }
            return View(robot);
        }

        // GET: DataManage/Robots/Create
        public ActionResult Create()
        {
            ViewBag.RobotId = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: DataManage/Robots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RobotId,Name,Hieght,Width,Length,DescriptionId")] Robot robot)
        {
            if (ModelState.IsValid)
            {
                db.Robots.Add(robot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RobotId = new SelectList(db.Teams, "TeamId", "TeamName", robot.RobotId);
            return View(robot);
        }

        // GET: DataManage/Robots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Robot robot = db.Robots.Find(id);
            if (robot == null)
            {
                return HttpNotFound();
            }
            ViewBag.RobotId = new SelectList(db.Teams, "TeamId", "TeamName", robot.RobotId);
            return View(robot);
        }

        // POST: DataManage/Robots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RobotId,Name,Hieght,Width,Length,DescriptionId")] Robot robot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(robot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RobotId = new SelectList(db.Teams, "TeamId", "TeamName", robot.RobotId);
            return View(robot);
        }

        // GET: DataManage/Robots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Robot robot = db.Robots.Find(id);
            if (robot == null)
            {
                return HttpNotFound();
            }
            return View(robot);
        }

        // POST: DataManage/Robots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Robot robot = db.Robots.Find(id);
            db.Robots.Remove(robot);
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
