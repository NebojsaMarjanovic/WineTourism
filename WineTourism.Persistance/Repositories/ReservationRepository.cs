using Microsoft.EntityFrameworkCore;
using WineTourism.Application.Interfaces.Repositories;
using WineTourism.Domain.Entities;
using WineTourism.Persistance.Contexts;

namespace WineTourism.Persistance.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Reservation> AddAsync(Reservation entity, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
            return entity;
        }

        public Task DeleteAsync(Reservation entity)
        {
            return Task.FromResult(_dbContext.Remove(entity));
        }

        public Task<List<Reservation>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Reservations.Include(r=>r.City)
                                            .Include(r=>r.User)
                                            .Include(r=>r.City.Winery)
                                            .Include(r => r.City.Hotel)
                                            .ToListAsync(cancellationToken);
        }

        public Task<Reservation?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return _dbContext.Reservations.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public Task UpdateAsync(Reservation entity, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dbContext.Entry(entity).State = EntityState.Modified);
        }
    }
}
