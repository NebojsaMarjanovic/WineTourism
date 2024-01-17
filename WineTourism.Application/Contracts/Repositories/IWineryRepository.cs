using WineTourism.Domain.Entities;

namespace WineTourism.Application.Contracts.Repositories
{
    public interface IWineryRepository 
    {
        public Task<List<Winery>> SearchByDestination(int destinationId, CancellationToken cancellationToken);
    }
}
