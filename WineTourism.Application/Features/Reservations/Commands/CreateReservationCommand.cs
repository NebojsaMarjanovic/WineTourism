using MediatR;
using WineTourism.Application.Interfaces.Repositories;
using WineTourism.Domain.Entities;
using WineTourism.Shared;

namespace WineTourism.Application.Features.Reservations.Commands
{
    public record CreateReservationCommand : IRequest<Result<string>>
    {
        public int CityId { get; set; }
        public string UserId { get; set; }
        public int NumberOfPersons { get; set; }
        public bool BreakfastInHotel { get; set; }
        public bool DinnerInWinery { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
    }

    internal class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetByIdAsync(request.CityId, cancellationToken);
            if (city != null)
            {
                return await Result<string>.FailureAsync("City not found.");
            }
            var reservation = new Reservation()
            {
                Id = Guid.NewGuid().ToString(),
                CityId = request.CityId,
                UserId = request.UserId,
                NumberOfPersons = request.NumberOfPersons,
                BreakfastInHotel = request.BreakfastInHotel,
                DinnerInWinery = request.DinnerInWinery,
                Note = request.Note,
                Price = request.NumberOfPersons * request.Price
            };

            await _unitOfWork.ReservationRepository.AddAsync(reservation, cancellationToken);
         
            city!.AvailableSeatsCount -= reservation.NumberOfPersons;
            await _unitOfWork.CityRepository.UpdateAsync(city, cancellationToken);

            await _unitOfWork.Save(cancellationToken);

            return await Result<string>.SuccessAsync(reservation.Id, "Reservation created.");
        }
    }
}
