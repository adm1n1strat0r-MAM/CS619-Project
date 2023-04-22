using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCinemaMS.Models
{
    public class SeatReserved
    {
        [Key]
        public int Id { get; set; }

        //Screening
        public int ScreeningId { get; set; }

        //Reservation
        public int ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        public Reservation reservation { get; set; }

        //Seat
        public int SeatId { get; set; }
        [ForeignKey("SeatId")]
        public Seats Seats { get; set; }
    }
}
