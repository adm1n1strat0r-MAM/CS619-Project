namespace eCinemaMS.Models.ViewModels.ReservationViewModels
{
    public class DropDownMoviesVM
    {
        public DropDownMoviesVM()
        {
            movies = new List<Movies>();
        }
        public List<Movies> movies { get; set; }
    }
}
