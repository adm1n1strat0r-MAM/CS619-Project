namespace eCinemaMS.Models.ViewModels.ReservationViewModels
{
    public class bookingVM
    {
        public Movies movie { get; set; }
        public Screening screening { get; set; }
        public int cost { get; set; }
        public int qty { get; set; }
        public int subtotal { get; set; }
    }
}
