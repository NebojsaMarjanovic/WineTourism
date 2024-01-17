using WineTourism.Application.DTOs;
using WineTourism.Domain.Entities;
using WineTourism.Shared;

namespace WineTourism.Application.Contracts
{
    public interface IReservationService
    {
        Task<Result<Reservation>> CreateReservation(CreateReservationDTO reservationDto);
        Task<Result<IEnumerable<Reservation>>> GetAllReservationAsync();
    }
}
