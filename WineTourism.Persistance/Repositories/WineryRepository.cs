using Microsoft.EntityFrameworkCore;
using WineTourism.Application.Interfaces.Repositories;
using WineTourism.Domain.Entities;

namespace WineTourism.Persistance.Repositories
{
    public class WineryRepository : IWineryRepository
    {
        private readonly IGenericRepository<Winery> _repository;

        public WineryRepository(IGenericRepository<Winery> repository)
        {
            _repository = repository;
        }

        public async Task<List<Winery>> SearchByCity(int cityId)
        {
            return await _repository.Entites.Where(x => x.CityId == cityId).ToListAsync();
        }
    }
}
