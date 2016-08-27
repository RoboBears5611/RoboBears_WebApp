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
    public class NotesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataManage/Notes
        public ActionResult Index()
        {
            var notes = db.Notes.Include(n => n.Description);
            return View(notes.ToList());
        }

        // GET: DataManage/Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: DataManage/Notes/Create
        public ActionResult Create()
        {
            ViewBag.DescriptionId = new SelectList(db.Descriptions, "DescriptionId", "Summary");
            return View();
        }

        // POST: DataManage/Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoteId,DescriptionId,Body")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DescriptionId = new SelectList(db.Descriptions, "DescriptionId", "Summary", note.DescriptionId);
            return View(note);
        }

        // GET: DataManage/Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.DescriptionId = new SelectList(db.Descriptions, "DescriptionId", "Summary", note.DescriptionId);
            return View(note);
        }

        // POST: DataManage/Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoteId,DescriptionId,Body")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DescriptionId = new SelectList(db.Descriptions, "DescriptionId", "Summary", note.DescriptionId);
            return View(note);
        }

        // GET: DataManage/Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: DataManage/Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
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
