using Koora.Models.MyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.ViewModels
{
    public class VotePageViewModel
    {
        public IEnumerable<Nominee> nominees { get; set; }
        [Required(ErrorMessage ="Please select a nominee")]
        public int nomineeId { get; set; }        
        
        public string name { get; set; }
        
        public int positionId { get; set; }
    }
}