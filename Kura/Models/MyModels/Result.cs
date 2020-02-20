using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class Result
    {
        public int id { get; set; }
        
        [Required]
        [Display(Name="Total votes")]
        public int totalVotes { get; set; }

        public Nominee nominee { get; set; }
        
        [Required]
        public int nomineeWinnerId { get; set; }
    }
}