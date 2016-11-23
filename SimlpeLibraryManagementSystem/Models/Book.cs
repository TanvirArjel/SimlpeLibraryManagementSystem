using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimlpeLibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public bool Status { get; set; }
        [Display(Name = "Book Category")]
        public string BookCategory { get; set; }
        [Display(Name = "Book Author")]
        public string BookAuthor { get; set; }

        public virtual ICollection<BookIssue> BookIssue { get; set; }
    }
}