using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eCinemaMS.Models.ViewModels.AccountsViewModels
{
    public class SignUpUserVM
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter username")]
        public string UserName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please enter Mobile Number")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Mobile Number id not valid")]
        public long Phone { get; set; }

        [Display(Name = "CNIC Number")]
        [Required(ErrorMessage = "Please enter CNIC Number")]
        [RegularExpression(@"^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        public string CNIC { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter valid Email")]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Passowrd")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password con't matched")]
        public string ConfirmPassword { get; set; }

        //public string Role { get; set; }
        public bool isRemember { get; set; }
    }
}
