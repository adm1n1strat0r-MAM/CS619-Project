using eCinemaMS.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCinemaMS.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public bool Paid { get; set; }

        //Screening
        public int ScreeningId { get; set; }
        [ForeignKey("ScreeningId")]
        public Screening screening { get; set; }

        //user
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int cost { get; set; }
        public int qty { get; set; }
        public int subtotal { get; set; }
        public int MovieId { get; set; }
    }
}
