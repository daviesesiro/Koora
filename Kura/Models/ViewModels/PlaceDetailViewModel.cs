using Koora.Models.MyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Koora.Models.ViewModels
{
    public class PlaceDetailViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public int RateId { get; set; }

        [Required]
        [Range(0, 5)]
        public int Star {  get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        

        [StringLength(128)]
        public string UserId { get; set; }
        public int PlaceId { get; set; }


    }
}