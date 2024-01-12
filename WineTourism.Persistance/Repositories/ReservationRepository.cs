using WineTourism.Application.Interfaces.Repositories;
using WineTourism.Domain.Entities;

namespace WineTourism.Persistance.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IGenericRepository<Reservation> _repository;

        public ReservationRepository(IGenericRepository<Reservation> repository)
        {
            _repository = repository;
        }
    }
}
