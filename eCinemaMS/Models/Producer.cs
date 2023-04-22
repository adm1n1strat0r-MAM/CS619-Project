using eCinemaMS.Data.Repositories;
using System.ComponentModel.DataAnnotations;

namespace eCinemaMS.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string profilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName is  Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name is must be between 3 to 50 chars")]
        public string fullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "BioGraphy is  Required")]
        public string Bio { get; set; }

        //Relationship
        public List<Movies>? movies { get; set; }
    }
}
