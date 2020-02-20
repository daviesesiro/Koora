using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class CastVote
    {
        public int id { get; set; }

        [ForeignKey("userId")]
        public AspNetUser user { get; set; }
        [ForeignKey("positionId")]
        
        public Position position { get; set; }
        [ForeignKey("nomineeId")]
        public Nominee nominee { get; set; }
        
        [Required]
        [StringLength(128)]
        public string userId { get; set; }

        [Required]
        public int nomineeId { get; set; }

       
        public int positionId { get; set; }
    }
}