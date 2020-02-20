using System.ComponentModel.DataAnnotations;

namespace Koora.Models.MyModels
{
    public class Position
    {
        public int id { get; set; }

        [Required]
        [Display(Name ="Position")]
        public string name { get; set; }

        
        [Display(Name ="Event")]
        public Event _event { get; set; }
        
        [Required]        
        public int eventId { get; set; }
    }
}