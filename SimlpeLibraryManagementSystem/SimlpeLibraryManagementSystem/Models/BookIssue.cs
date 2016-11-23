using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimlpeLibraryManagementSystem.Models
{
    public class BookIssue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookIssueId { get; set; }

        public int MemberId { get; set; }
        public int BookId { get; set; }
        [Display(Name = "Date Of Issue")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfIssue { get; set; }
        public bool Status { get; set; }

        public virtual Member Member { get; set; }  
        public virtual Book Book { get; set; }
    }
}