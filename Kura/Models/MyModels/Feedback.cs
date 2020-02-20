using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koora.Models.MyModels
{
    public class Feedback
    {
        public int Id { get; set; }

        public string Sender { get; set; }

        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}