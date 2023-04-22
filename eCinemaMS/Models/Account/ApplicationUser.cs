using Microsoft.AspNetCore.Identity;

namespace eCinemaMS.Models.Account
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public string CNIC { get; set; }
    }
}
