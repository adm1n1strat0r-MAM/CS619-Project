using eCinemaMS.Data.Repositories;
using eCinemaMS.Models;
using Microsoft.EntityFrameworkCore;

namespace eCinemaMS.Data.Servies
{
    public class ActorServices : EntityBaseRepository<Actor>, IActorsServices
    {
        public ActorServices(AppDbContext context) : base(context) { }
    }
}
