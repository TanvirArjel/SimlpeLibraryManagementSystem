using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimlpeLibraryManagementSystem.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        [Display(Name = "Member Name")]
        public string MemberName { get; set; }
        public bool? Status { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        
        public virtual ICollection<BookIssue> BookIssue { get; set; }
    }
}