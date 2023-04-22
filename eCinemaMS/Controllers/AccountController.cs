using eCinemaMS.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using eCinemaMS.Models.ViewModels.AccountsViewModels;

namespace eCinemaMS.Controllers
{
    public class AccountController : Controller
    {
        //private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            ApplicationUser user = userManager.FindByIdAsync(userId).Result;
            return View(user);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if(Url.IsLocalUrl(ViewBag.ReturnUrl))
                {
                    return Redirect(ViewBag.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.isRemember, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                { 
                    FullName = model.UserName,
                    UserName = model.Email, 
                    Email = model.Email, 
                    PhoneNumber = model.Phone.ToString() ,
                    CNIC = model.CNIC
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //generation of the email token
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("verifyEmail", "Account", new { userId = user.Id, code = token }, Request.Scheme, Request.Host.ToString());

                    string emailSubject = "verify Email";

                    string emailBody = "Please click here to verify your Account \n\n" + $"<a href=\"{confirmationLink}\">Verify Email</a>";

                    SendEmail(user.Email, emailSubject, emailBody);
                    
                    return RedirectToAction("EmailConfirmation");
                    
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }


        public async Task<IActionResult> verifyEmail(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();
            var resutl = await userManager.ConfirmEmailAsync(user, code);
            if (resutl.Succeeded)
            {
                if(signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                {
                    return RedirectToAction("ListUser", "Administration");
                }
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public void SendEmail(string emailAddress, string emailSubject, string emailBody)
        {
            var fromAddress = new MailAddress("aa17262211@gmail.com");
            var fromPassword = "epicvhynkytjnrjk";
            var toAddress = new MailAddress(emailAddress);

            string subject = emailSubject;
            string body = emailBody;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            smtp.Send(message);
        }
    }
}
