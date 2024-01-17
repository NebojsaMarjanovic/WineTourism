using Microsoft.EntityFrameworkCore;
using WineTourism.Application.Contracts.Repositories;
using WineTourism.Domain.Entities;
using WineTourism.Persistance.Contexts;

namespace WineTourism.Persistance.Repositories
{
    public class WineryRepository : IWineryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WineryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Winery>> SearchByDestination(int destinationId, CancellationToken cancellationToken)
        {
            return await _dbContext.Wineries.Where(x => x.DestinationId == destinationId).ToListAsync(cancellationToken);
        }
    }
}
