using WineTourism.Domain.Entities;

namespace WineTourism.Application.Interfaces.Repositories
{
    public interface IWineryRepository 
    {
        public Task<List<Winery>> SearchByCity(int cityId, CancellationToken cancellationToken);
    }
}
