using eCinemaMS.Data.Repositories;
using eCinemaMS.Models;
using Microsoft.EntityFrameworkCore;

namespace eCinemaMS.Data.Servies
{
    public class ProducerServices :EntityBaseRepository<Producer> , IProducersServices
    {
        public ProducerServices(AppDbContext context) : base(context) { }
    }
}
