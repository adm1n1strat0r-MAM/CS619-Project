using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCinemaMS.Models
{
    public class Seats
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Seats Number")]
        public string SeatNo { get; set; }

        //Relationship
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema cinema { get; set; }
    }
}
