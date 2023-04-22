using System.ComponentModel.DataAnnotations;

namespace eCinemaMS.Models.Account
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public long? Phone { get; set; }
        public string CNIC { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
        //public string Role { get; set; }
    }
}
