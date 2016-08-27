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
    public class MatchesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Matches
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.BlueAllianceTeam1).Include(m => m.BlueAllianceTeam2).Include(m => m.Competition).Include(m => m.MatchType).Include(m => m.RedAllianceTeam1).Include(m => m.RedAllianceTeam2);
            return View(matches.ToList());
        }

        // GET: DataManage/Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: DataManage/Matches/Create
        public ActionResult Create()
        {
            ViewBag.BlueAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName");
            ViewBag.BlueAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName");
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionID", "Title");
            ViewBag.MatchTypeId = new SelectList(db.MatchTypes, "MatchTypeId", "MatchTypeName");
            ViewBag.RedAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName");
            ViewBag.RedAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: DataManage/Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,Name,BlueAllianceTeam1Id,BlueAllianceTeam2Id,RedAllianceTeam1Id,RedAllianceTeam2Id,WinnerIsBlue,DescriptionId,CompetitionId,MatchTypeId")] Match match)
        {
            if (ModelState.IsValid)
            {
                match.Competition = db.Competitions.Find(match.CompetitionId);
                if(match.Competition.Teams == null)
                {
                    match.Competition.Teams = new List<Team>();
                }
                db.Matches.Add(match);
                foreach(var teamId in new[] { match.BlueAllianceTeam1Id, match.BlueAllianceTeam2Id, match.RedAllianceTeam1Id, match.RedAllianceTeam2Id })
                {
                    Team team = db.Teams.Find(teamId);
                    if(team != null)
                    {
                        if (!match.Competition.Teams.Contains(team))
                        {
                            match.Competition.Teams.Add(team);
                        }
                    }
                }
                db.Entry(match.Competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlueAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName", match.BlueAllianceTeam1Id);
            ViewBag.BlueAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName", match.BlueAllianceTeam2Id);
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionID", "Title", match.CompetitionId);
            ViewBag.MatchTypeId = new SelectList(db.MatchTypes, "MatchTypeId", "MatchTypeName", match.MatchTypeId);
            ViewBag.RedAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName", match.RedAllianceTeam1Id);
            ViewBag.RedAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName", match.RedAllianceTeam2Id);
            return View(match);
        }

        // GET: DataManage/Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlueAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName", match.BlueAllianceTeam1Id);
            ViewBag.BlueAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName", match.BlueAllianceTeam2Id);
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionID", "Title", match.CompetitionId);
            ViewBag.MatchTypeId = new SelectList(db.MatchTypes, "MatchTypeId", "MatchTypeName", match.MatchTypeId);
            ViewBag.RedAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName", match.RedAllianceTeam1Id);
            ViewBag.RedAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName", match.RedAllianceTeam2Id);
            return View(match);
        }

        // POST: DataManage/Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,Name,BlueAllianceTeam1Id,BlueAllianceTeam2Id,RedAllianceTeam1Id,RedAllianceTeam2Id,WinnerIsBlue,DescriptionId,CompetitionId,MatchTypeId")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlueAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName", match.BlueAllianceTeam1Id);
            ViewBag.BlueAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName", match.BlueAllianceTeam2Id);
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionID", "Title", match.CompetitionId);
            ViewBag.MatchTypeId = new SelectList(db.MatchTypes, "MatchTypeId", "MatchTypeName", match.MatchTypeId);
            ViewBag.RedAllianceTeam1Id = new SelectList(db.Teams, "TeamId", "TeamName", match.RedAllianceTeam1Id);
            ViewBag.RedAllianceTeam2Id = new SelectList(db.Teams, "TeamId", "TeamName", match.RedAllianceTeam2Id);
            return View(match);
        }

        // GET: DataManage/Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: DataManage/Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
