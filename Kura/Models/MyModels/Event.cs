using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class Event
    {
        public int id { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImgDirectory { get; set; }

        public bool IsOngoing { get; set; }

        [Required]
        [DataType("date")]
        public DateTime createdTime { get; set; }
        public DateTime? endedTime { get; set; }
    }
}