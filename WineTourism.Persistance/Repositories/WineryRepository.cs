using Microsoft.EntityFrameworkCore;
using WineTourism.Application.Interfaces.Repositories;
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

        public async Task<List<Winery>> SearchByCity(int cityId, CancellationToken cancellationToken)
        {
            return await _dbContext.Wineries.Where(x => x.CityId == cityId).ToListAsync(cancellationToken);
        }
    }
}
