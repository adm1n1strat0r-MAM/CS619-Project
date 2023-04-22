using eCinemaMS.Models.Account;
using eCinemaMS.Models.ViewModels.AdminVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.FinancialConnections;

namespace eCinemaMS.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        //private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public PaymentController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Subscription()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SubPay()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            ApplicationUser user = userManager.FindByIdAsync(userId).Result;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> SubPay(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var userId = userManager.GetUserId(HttpContext.User);
            var user = await userManager.FindByIdAsync(userId);

            

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 499900,
                Description = "Subscription",
                Currency = "PKR",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail
            });


            IdentityResult result = null;
            var memberRole = await roleManager.FindByNameAsync("Member"); // Retrieve the "Member" role
            if (memberRole != null)
            {
                result = await userManager.AddToRoleAsync(user, memberRole.Name); // Add the user to the "Member" role
            }

            if (charge.Status == "succeeded" && result.Succeeded)
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
