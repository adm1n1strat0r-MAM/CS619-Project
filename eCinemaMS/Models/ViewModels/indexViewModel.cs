namespace eCinemaMS.Models.ViewModels
{
    public class indexViewModel
    {
        public IEnumerable<Movies> Movies { get; set; }
        public IEnumerable<Cinema> cinemas { get; set; }
        public IEnumerable<Producer> producer { get; set; }
        public IEnumerable<Actor> actors { get; set; }
    }
}
