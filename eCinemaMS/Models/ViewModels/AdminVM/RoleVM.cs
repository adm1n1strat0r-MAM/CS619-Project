using System.ComponentModel.DataAnnotations;

namespace eCinemaMS.Models.ViewModels.AdminVM
{
    public class RoleVM
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string role { get; set; }
    }
}
