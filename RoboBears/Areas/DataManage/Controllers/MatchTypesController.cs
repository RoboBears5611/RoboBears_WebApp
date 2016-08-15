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
    public class MatchTypesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/MatchTypes
        public ActionResult Index()
        {
            return View(db.MatchTypes.ToList());
        }

        // GET: DataManage/MatchTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchType matchType = db.MatchTypes.Find(id);
            if (matchType == null)
            {
                return HttpNotFound();
            }
            return View(matchType);
        }

        // GET: DataManage/MatchTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataManage/MatchTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchTypeId,MatchTypeName")] MatchType matchType)
        {
            if (ModelState.IsValid)
            {
                db.MatchTypes.Add(matchType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matchType);
        }

        // GET: DataManage/MatchTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchType matchType = db.MatchTypes.Find(id);
            if (matchType == null)
            {
                return HttpNotFound();
            }
            return View(matchType);
        }

        // POST: DataManage/MatchTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchTypeId,MatchTypeName")] MatchType matchType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matchType);
        }

        // GET: DataManage/MatchTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchType matchType = db.MatchTypes.Find(id);
            if (matchType == null)
            {
                return HttpNotFound();
            }
            return View(matchType);
        }

        // POST: DataManage/MatchTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchType matchType = db.MatchTypes.Find(id);
            db.MatchTypes.Remove(matchType);
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
