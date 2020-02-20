using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class Place
    {
        public int id { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name ="Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string location { get; set; }
    }
}