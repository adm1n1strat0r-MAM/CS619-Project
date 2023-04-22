using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eCinemaMS.Models
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "When Screening Start")]
        public DateTime ScreeningStart { get; set; }

        //Relationship
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies movie { get; set; }
    }
}
