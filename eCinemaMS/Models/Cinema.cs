using eCinemaMS.Data.Repositories;
using System.ComponentModel.DataAnnotations;

namespace eCinemaMS.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is  Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name is must be between 3 to 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is  Required")]
        public string Address { get; set; }

        [Display(Name = "Cenima Seats")]
        [Required(ErrorMessage = "Seats is required")]
        public int Seats { get; set; }

        //Relationship
        public List<Movies>? Movie { get; set; }

    }
}
