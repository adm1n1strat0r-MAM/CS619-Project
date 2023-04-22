using eCinemaMS.Data.Enums;
using eCinemaMS.Models;

namespace eCinemaMS.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var Context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                Context.Database.EnsureCreated();

                //Cinema
                if (!Context.Cinemas.Any())
                {
                    Context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Address = "This is the Address of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Address = "This is the Address of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Address = "This is the Address of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Address = "This is the Address of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Address = "This is the Address of the first cinema"
                        },
                    });
                    Context.SaveChanges();
                }
                //Actor
                if (!Context.Actors.Any())
                {
                    Context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            fullName = "Matt LeBlanc",
                            Bio = "This is the Bio of the first actor",
                            profilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            fullName = "Chrix Tucker",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            fullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            fullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            fullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    Context.SaveChanges();
                }
                //Producre
                if (!Context.Producers.Any())
                {
                    Context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            fullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            profilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            fullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            fullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            fullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            fullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            profilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    Context.SaveChanges();
                }
                //Movie
                if (!Context.Movies.Any())
                {
                    Context.Movies.AddRange(new List<Movies>()
                    {
                        new Movies()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Duration = "1:12:59",
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Today.AddHours(3),
                            CinemaId = 3,
                            ProducerId = 3,
                            movieCategory = MovieCategory.Documentary
                        },
                        new Movies()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Duration = "1:12:59",
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Today.AddHours(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            movieCategory = MovieCategory.Action
                        },
                        new Movies()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Duration = "1:12:59",
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Today.AddHours(3),
                            CinemaId = 4,
                            ProducerId = 4,
                            movieCategory = MovieCategory.Horror
                        },
                        new Movies()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Duration = "1:12:59",
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Today.AddHours(3),
                            CinemaId = 1,
                            ProducerId = 2,
                            movieCategory = MovieCategory.Documentary
                        },
                        new Movies()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Duration = "1:12:59",
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Today.AddHours(3),
                            CinemaId = 1,
                            ProducerId = 3,
                            movieCategory = MovieCategory.Cartoon
                        },
                        new Movies()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Duration = "1:12:59",
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Today.AddHours(3),
                            CinemaId = 1,
                            ProducerId = 5,
                            movieCategory = MovieCategory.Drama
                        }
                    });
                    Context.SaveChanges();
                }
                //Actor_Movie
                if (!Context.Actors_Movie.Any())
                {
                    Context.Actors_Movie.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    Context.SaveChanges();
                }
            }
        }
    }
}
