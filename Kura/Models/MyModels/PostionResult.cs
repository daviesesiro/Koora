using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class PostionResult
    {
        public int id { get; set; }
        public Position position { get; set; }
        public Result result { get; set; }
        
        [Required]
        public int positionId { get; set; }

        [Required]
        public int resultId { get; set; }

    }
}