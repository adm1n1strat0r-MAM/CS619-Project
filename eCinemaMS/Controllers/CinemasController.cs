using eCinemaMS.Data;
using eCinemaMS.Data.Servies;
using eCinemaMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCinemaMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CinemasController : Controller
    {
        private readonly ICinemasServices _service;

        public CinemasController(ICinemasServices service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Address, Seats")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var cinemaDetail = await _service.GetByIdAsync(id);

            if (cinemaDetail == null) return View("Empty");
            return View(cinemaDetail);
        }

        //Get: Cinemas/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var CinemaDetail = await _service.GetByIdAsync(id);
            if (CinemaDetail == null) return View("Error");
            return View(CinemaDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Logo,Name,Address, Seats")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET:// Cinema/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetait = await _service.GetByIdAsync(id);
            if (cinemaDetait == null) return View("Error");
            return View(cinemaDetait);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetail = await _service.GetByIdAsync(id);
            if (cinemaDetail == null) return View("Error");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
