using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimlpeLibraryManagementSystem.Models;

namespace SimlpeLibraryManagementSystem.Controllers
{
    public class BookIssueController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();

        // GET: BookIssue
        public ActionResult Index()
        {
            var bookIssues = db.BookIssues.Include(b => b.Book).Include(b => b.Member);
            return View(bookIssues.ToList());
        }

        // GET: BookIssue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            return View(bookIssue);
        }

        // GET: BookIssue/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName");
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName");
            return View();
        }

        // POST: BookIssue/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookIssueId,MemberId,BookId,DateOfIssue,Status")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                db.BookIssues.Add(bookIssue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", bookIssue.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssue.MemberId);
            return View(bookIssue);
        }

        // GET: BookIssue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", bookIssue.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssue.MemberId);
            return View(bookIssue);
        }

        // POST: BookIssue/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookIssueId,MemberId,BookId,DateOfIssue,Status")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookIssue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", bookIssue.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssue.MemberId);
            return View(bookIssue);
        }

        // GET: BookIssue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            return View(bookIssue);
        }

        // POST: BookIssue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookIssue bookIssue = db.BookIssues.Find(id);
            db.BookIssues.Remove(bookIssue);
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
