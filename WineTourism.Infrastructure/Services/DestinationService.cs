using WineTourism.Application.Contracts;
using WineTourism.Application.Contracts.Repositories;
using WineTourism.Application.DTOs;
using WineTourism.Domain.Entities;
using WineTourism.Shared;

namespace WineTourism.Infrastructure.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DestinationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> DeleteDestination(DestinationDTO destinationDto, CancellationToken cancellationToken)
        {
            Destination destination = new Destination()
            {
                Id = destinationDto.DestinationId
            };

            try
            {
                await _unitOfWork.DestinationRepository.DeleteAsync(destination);
                return await Result<string>.SuccessAsync("Destination has been deleteted successfully");
            }
            catch (Exception ex)
            {
                return await Result<string>.FailureAsync("Error while deleting destination");
            }
        }

        public async Task<Result<IEnumerable<Destination>>> GetAllDestinations(CancellationToken cancellationToken)
        {
            try
            {
                var cities = await _unitOfWork.DestinationRepository.GetAllAsync(cancellationToken);
                return await Result<IEnumerable<Destination>>.SuccessAsync(cities);
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<Destination>>.FailureAsync(ex.Message);
            }
        }

        public async Task<Result<Destination>> UpdateDestination(Destination destination, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.DestinationRepository.UpdateAsync(destination, cancellationToken);
                return await Result<Destination>.SuccessAsync(destination);

            }
            catch (Exception ex)
            {
                return await Result<Destination>.FailureAsync(ex.Message);
            }
        }
    }
}
