using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class Student
    {
        public int id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Last name")]
        public string lastName { get; set; }
        
        [EmailAddress]
        [Display(Name ="Email")]
        public string email { get; set; }

    }
}