using WineTourism.Domain.Entities;
using WineTourism.Persistance.Contexts;

namespace WineTourism.Persistance.Repositories
{
    public class DestinationRepository : GenericRepository<Destination>
    {
        public DestinationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
