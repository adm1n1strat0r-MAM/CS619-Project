using eCinemaMS.Data.Repositories;
using eCinemaMS.Models;
using eCinemaMS.Models.Account;
using eCinemaMS.Models.ViewModels.MoviesViewModels;
using eCinemaMS.Models.ViewModels.ReservationViewModels;
using Microsoft.EntityFrameworkCore;

namespace eCinemaMS.Data.Servies
{
    public class MoviesService : EntityBaseRepository<Movies>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMoviesAsync(NewMovieVM movie)
        {
            var newMovie = new Movies()
            {
                Name = movie.Name,
                Description = movie.Description,
                ImageUrl = movie.ImageURL,
                CinemaId = movie.CinemaId,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                movieCategory = movie.MovieCategory,
                ProducerId = movie.ProducerId,
                Duration = movie.Duration,
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            foreach (var actorId in movie.ActorIds)
            {
                var movie_acotr = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movie.AddAsync(movie_acotr);
            }
            await _context.SaveChangesAsync();
        }
        public async Task AddNewMoviesScreeningAsync(ScreeningVM screening)
        {
            var screen = new Screening()
            {
                ScreeningStart = screening.ScreeningStart,
                MovieId = screening.MovieId,
            };
            await _context.screenings.AddAsync(screen);
            await _context.SaveChangesAsync();

        }
        public async Task<Movies> GetMovieByIdAsync(int id)
        {
            var movieDetail = await _context.Movies
                .Include(c => c.cinema)
                .Include(p => p.producer)
                .Include(am => am.actors_movies).ThenInclude(a => a.actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetail;
        }
        public async Task<bookingVM> booking(int id)
        {
            var booking = new bookingVM
            {
                movie = await GetMovieByIdAsync(id),
                screening = await _context.screenings.FirstOrDefaultAsync(n => n.MovieId == id)
            };
            return booking;
        }
        public async Task Reservation(bookingVM reserve, ApplicationUser User)
        {
            var reservation = new Reservation
            {
                UserId = User.Id,
                cost = reserve.cost,
                qty = reserve.qty,
                subtotal = reserve.cost * reserve.qty,
                ScreeningId = reserve.screening.Id,
                Paid = true
            };
            await _context.reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task<List<reservationVM>> allReservation(string userId)
        {
            var reservations = await _context.reservations
                .Where(r => r.UserId == userId)
                .Select(r => new reservationVM
                {
                    Id = r.Id,
                    ScreeningTime = r.screening.ScreeningStart,
                    cost = r.cost,
                    qty = r.qty,
                    subtotal = r.subtotal
                })
                .ToListAsync();

            return reservations;
        }
        public async Task<List<reservationVM>> allTickets()
        {
            var reservations = await _context.reservations
                .Select(r => new reservationVM
                {
                    Id = r.Id,
                    ScreeningTime = r.screening.ScreeningStart,
                    cost = r.cost,
                    qty = r.qty,
                    subtotal = r.subtotal
                })
                .ToListAsync();

            return reservations;
        }


        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var respone = new NewMovieDropdownsVM()
            {
                actors = await _context.Actors.OrderBy(n => n.fullName).ToListAsync(),
                cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                producers = await _context.Producers.OrderBy(n => n.fullName).ToListAsync()
            };
            return respone;
        }
        public async Task<DropDownMoviesVM> GetMovieDropdowns()
        {
            var respone = new DropDownMoviesVM()
            {
                movies = await _context.Movies.OrderBy(n => n.Name).ToListAsync()
            };
            return respone;
        }

        public async Task UpdateMovieAsync(NewMovieVM movie)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == movie.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = movie.Name;
                dbMovie.Description = movie.Description;
                dbMovie.Duration = movie.Duration;
                dbMovie.ImageUrl = movie.ImageURL;
                dbMovie.CinemaId = movie.CinemaId;
                dbMovie.StartDate = movie.StartDate;
                dbMovie.EndDate = movie.EndDate;
                dbMovie.movieCategory = movie.MovieCategory;
                dbMovie.ProducerId = movie.ProducerId;
                await _context.SaveChangesAsync();
            }

            var exist_actor = _context.Actors_Movie.Where(n => n.MovieId == movie.Id).ToList();
            _context.Actors_Movie.RemoveRange(exist_actor);
            await _context.SaveChangesAsync();

            foreach (var actorId in movie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId,
                };
                await _context.Actors_Movie.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
