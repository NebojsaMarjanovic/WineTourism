using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WineTourism.Domain.Common;
using WineTourism.Application.Common;

namespace WineTourism.Persistance.Data.Interceptors
{
    public class AuditableEntityInterceptors : SaveChangesInterceptor
    {
        private readonly IUser _user;
        private readonly TimeProvider _dateTime;

        public AuditableEntityInterceptors(IUser user, TimeProvider dateTime)
        {
            _user = user;
            _dateTime = dateTime;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;
            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.CreatedBy = _user.Id;
                    entry.Entity.CreatedOn = _dateTime.GetUtcNow();
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedBy = _user.Id;
                    entry.Entity.UpdatedOn = _dateTime.GetUtcNow();
                }
            }
        }
    }
}
