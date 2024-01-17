using WineTourism.Application.Contracts.Repositories;
using WineTourism.Domain.Entities;
using WineTourism.Persistance.Contexts;

namespace WineTourism.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IGenericRepository<Reservation> _reservationRepository;
        private IGenericRepository<User> _userRepository;
        private IWineryRepository _wineryRepository;
        private IGenericRepository<Destination> _destinationRepository;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _reservationRepository = new ReservationRepository(_dbContext);
            _userRepository = new UserRepository(_dbContext);
            _wineryRepository = new WineryRepository(_dbContext);
            _destinationRepository = new DestinationRepository(_dbContext);
        }

        public IGenericRepository<Reservation> ReservationRepository => _reservationRepository ??= new ReservationRepository(_dbContext);
        public IGenericRepository<User> UserRepository => _userRepository ??= new UserRepository(_dbContext);
        public IWineryRepository WineryRepository => _wineryRepository ??= new WineryRepository(_dbContext);
        public IGenericRepository<Destination> DestinationRepository => _destinationRepository ??= new DestinationRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
