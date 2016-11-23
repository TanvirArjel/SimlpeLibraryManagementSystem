using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimlpeLibraryManagementSystem.Models;
using WebGrease.Css.Extensions;

namespace SimlpeLibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();
        public ActionResult Index()
        {
            var summaryItem = from b in db.BookIssues
                              group b by new
                              {
                                  b.MemberId,
                                  b.DateOfIssue
                              }
                              into g
                              select new LibraryViewModel()
                              {
                                  Name = db.Members.Where(x => x.MemberId == g.Key.MemberId).Select(x => x.MemberName).FirstOrDefault(),
                                  DateOfIssue = g.Key.DateOfIssue,
                                  //Books = g.Select(b => b.BookId).ToList(),

                                  Books = db.Books.Where(x => g.Select(b => b.BookId).ToList().Contains(x.BookId)).Select(b => b.BookName).ToList(),
                              };

            return View(summaryItem);
        }
    }
}