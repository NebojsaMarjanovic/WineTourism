using WineTourism.Application.DTOs;
using WineTourism.Domain.Entities;
using WineTourism.Shared;

namespace WineTourism.Application.Contracts
{
    public interface IDestinationService
    {
        Task<Result<IEnumerable<Destination>>> GetAllDestinations(CancellationToken cancellationToken);
        Task<Result<string>> DeleteDestination(DestinationDTO destinationDto, CancellationToken cancellationToken);
        Task<Result<Destination>> UpdateDestination(Destination destination, CancellationToken cancellationToken);
    }
}
