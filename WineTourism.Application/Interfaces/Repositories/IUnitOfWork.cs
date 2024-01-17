using WineTourism.Domain.Common;
using WineTourism.Domain.Entities;

namespace WineTourism.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Reservation> ReservationRepository { get; }
        IGenericRepository<City> CityRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IWineryRepository WineryRepository { get; }

        Task Save(CancellationToken cancellationToken);
        Task Rollback();
    }
}
