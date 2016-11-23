using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimlpeLibraryManagementSystem.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("LibraryDbContext")
        {
            //Database.SetInitializer<LibraryDbContext>(new DropCreateDatabaseIfModelChanges<LibraryDbContext>());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
        //public DbSet<IssueDetails> IssueDetailses { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}