using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimlpeLibraryManagementSystem.Models
{
    public class LibraryViewModel
    {
        [Display(Name = "Issuer (Member)")]
        public string Name { get; set; }

        [Display(Name = "Date of Issue")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfIssue { get; set; }

        //public List<int> Books { get; set; }
        public List<string> Books { get; set; }
      
    }
}