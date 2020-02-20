using Koora.Models.MyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.ViewModels
{
    public class AdminPositionViewModel
    {
        [Required]
        public int id { get; set; }

        public int name { get; set; }

        public int eventId { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}