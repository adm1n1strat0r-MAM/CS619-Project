namespace eCinemaMS.Models.ViewModels.ReservationViewModels
{
    public class reservationVM
    {
        public int Id { get; set; }
        public DateTime ScreeningTime { get; set; }
        public int cost { get; set; }
        public int qty { get; set; }
        public int subtotal { get; set; }
    }
}
