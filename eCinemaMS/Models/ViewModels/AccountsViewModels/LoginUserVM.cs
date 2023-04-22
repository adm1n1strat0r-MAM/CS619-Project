using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eCinemaMS.Models.ViewModels.AccountsViewModels
{
    public class LoginUserVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isRemember { get; set; }
    }
}
