using eCinemaMS.Data;
using eCinemaMS.Data.Servies;
using eCinemaMS.Models.ViewModels.MoviesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eCinemaMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.cinema);
            return View(allMovies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Upcomming()
        {
            var allMovies = await _service.GetAllAsync(n => n.cinema);
            return View(allMovies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Filter", filteredResultNew);
            }
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "fullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "fullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "fullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "fullName");

                return View(movie);
            }
            await _service.AddNewMoviesAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetail = await _service.GetByIdAsync(id);
            if (movieDetail == null) return View("Error");

            var respone = new NewMovieVM()
            {
                Id = movieDetail.Id,
                Name = movieDetail.Name,
                Description = movieDetail.Description,
                Duration = movieDetail.Duration,
                StartDate = movieDetail.StartDate,
                EndDate = movieDetail.EndDate,
                ImageURL = movieDetail.ImageUrl,
                MovieCategory = movieDetail.movieCategory,
                CinemaId = movieDetail.CinemaId,
                ProducerId = movieDetail.ProducerId,
                //ActorIds = movieDetail.actors_movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "fullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "fullName");

            return View(respone);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("Error");
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "fullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "fullName");

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
