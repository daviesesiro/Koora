using System.ComponentModel.DataAnnotations;

namespace Koora.Models.MyModels
{
    public class Faculty
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Faculty name")]
        public string Name { get; set; }
    }
}