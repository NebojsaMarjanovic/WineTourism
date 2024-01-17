using WineTourism.Domain.Entities;

namespace WineTourism.Application.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Reservation> ReservationRepository { get; }
        IGenericRepository<Destination> DestinationRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IWineryRepository WineryRepository { get; }

        Task Save(CancellationToken cancellationToken);
        Task Rollback();
    }
}
