using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eCinemaMS.Models.ViewModels.ReservationViewModels
{
    public class ScreeningVM
    {
        public int Id { get; set; }

        [Display(Name = "When Screening Start")]
        public DateTime ScreeningStart { get; set; }

        [Display(Name = "Select a Movie")]
        public int MovieId { get; set; }
    }
}
