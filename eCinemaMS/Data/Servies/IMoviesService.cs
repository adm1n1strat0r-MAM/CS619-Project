using eCinemaMS.Data.Repositories;
using eCinemaMS.Models;
using eCinemaMS.Models.Account;
using eCinemaMS.Models.ViewModels.MoviesViewModels;
using eCinemaMS.Models.ViewModels.ReservationViewModels;

namespace eCinemaMS.Data.Servies
{
    public interface IMoviesService:IEntityBaseRepository<Movies>
    {
        Task<Movies> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task<DropDownMoviesVM> GetMovieDropdowns();
        Task AddNewMoviesAsync(NewMovieVM movie);
        Task AddNewMoviesScreeningAsync(ScreeningVM screening);
        Task UpdateMovieAsync(NewMovieVM movie);
        Task<bookingVM> booking(int id);
        Task Reservation(bookingVM reserve, ApplicationUser User);
        Task<List<reservationVM>> allReservation(string userId);
        Task<List<reservationVM>> allTickets();
    }
}
