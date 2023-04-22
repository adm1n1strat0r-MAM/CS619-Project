namespace eCinemaMS.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Movies movies { get; set; }

        public int ActorId { get; set; }
        public Actor actor { get; set; }

    }
}
