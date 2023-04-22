using eCinemaMS.Data.Servies;
using eCinemaMS.Models.Account;
using eCinemaMS.Models.ViewModels.ReservationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;

namespace eCinemaMS.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IMoviesService _service;
        private readonly UserManager<ApplicationUser> userManager;
        public ReservationController(IMoviesService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Booking(int id)
        {
            var bookingDetail = await _service.booking(id);
            return View(bookingDetail);
        }
        [HttpPost]
        public async Task<IActionResult> Booking(string stripeEmail, string stripeToken, int id, bookingVM booking)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = booking.cost * booking.qty * 100,
                Description = "Subscription",
                Currency = "PKR",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail
            });


            var userId = userManager.GetUserId(HttpContext.User);
            ApplicationUser user = userManager.FindByIdAsync(userId).Result;
            await _service.Reservation(booking, user);
            if (charge.Status == "succeeded")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Screening()
        {
            var movieDropdownsData = await _service.GetMovieDropdowns();
            ViewBag.movies = new SelectList(movieDropdownsData.movies, "Id", "Name");
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Screening(ScreeningVM screening)
        {
            await _service.AddNewMoviesScreeningAsync(screening);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Tickets()
        {
            var userId = userManager.GetUserId(User);
            var reservations = await _service.allReservation(userId);

            return View(reservations);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> allTickets()
        {
            var reservations = await _service.allTickets();

            return View(reservations);
        }
    }
}
