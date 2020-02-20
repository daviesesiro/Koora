using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class Rate
    {
        public int id { get; set; }
        
        [Required]
        [Range(0,5)]
        public int star { get; set; }

        [StringLength(100,MinimumLength =5)]
        [Display(Name ="Comment")]
        public string comment { get; set; }

        [ForeignKey("userId")]
        public AspNetUser User { get; set; }
        [ForeignKey("placeId")]
        public Place place { get; set; }

        [StringLength(128)]
        public string userId { get; set; }
        public int placeId { get; set; }

    }
}