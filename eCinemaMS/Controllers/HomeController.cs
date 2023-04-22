using eCinemaMS.Data;
using eCinemaMS.Models;
using eCinemaMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace eCinemaMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new indexViewModel();
            model.Movies = _context.Movies.ToList();
            model.cinemas = _context.Cinemas.ToList();
            model.producer = _context.Producers.ToList();
            model.actors = _context.Actors.ToList();
            return View(model);
        }

        public IActionResult FindUs()
        {
            return View();
        }
        public IActionResult Experience()
        {
            return View();
        }
    }
}
