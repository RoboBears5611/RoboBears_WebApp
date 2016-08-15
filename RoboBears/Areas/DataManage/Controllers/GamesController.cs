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
    public class GamesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Mat).Include(g => g.Year);
            return View(games.ToList());
        }

        // GET: DataManage/Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: DataManage/Games/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Mats, "MatId", "MatId");
            ViewBag.GameId = new SelectList(db.Years, "YearId", "YearId");
            return View();
        }

        // POST: DataManage/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Title,DescriptionId,YearId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Mats, "MatId", "MatId", game.GameId);
            ViewBag.GameId = new SelectList(db.Years, "YearId", "YearId", game.GameId);
            return View(game);
        }

        // GET: DataManage/Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Mats, "MatId", "MatId", game.GameId);
            ViewBag.GameId = new SelectList(db.Years, "YearId", "YearId", game.GameId);
            return View(game);
        }

        // POST: DataManage/Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Title,DescriptionId,YearId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Mats, "MatId", "MatId", game.GameId);
            ViewBag.GameId = new SelectList(db.Years, "YearId", "YearId", game.GameId);
            return View(game);
        }

        // GET: DataManage/Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: DataManage/Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
