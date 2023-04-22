using eCinemaMS.Data.Repositories;
using eCinemaMS.Models;
using Microsoft.EntityFrameworkCore;

namespace eCinemaMS.Data.Servies
{
    public class CinemaServices :EntityBaseRepository<Cinema>, ICinemasServices
    {
        public CinemaServices(AppDbContext context) : base(context) { }
    }
}
