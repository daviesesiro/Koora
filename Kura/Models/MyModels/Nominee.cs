using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class Nominee
    {
        public int id { get; set; }

        [Required]
        public string imageDirectory { get; set; }
        [Required]
        public string name { get; set; }
        public Position position { get; set; }

        [Required]
        public int positionId { get; set; }
        public int votes { get; set; }

    }
}