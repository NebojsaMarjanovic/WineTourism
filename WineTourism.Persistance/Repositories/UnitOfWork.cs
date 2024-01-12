using Microsoft.EntityFrameworkCore;
using WineTourism.Application.Interfaces.Repositories;
using WineTourism.Domain.Common;

namespace WineTourism.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    //_dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
        {
            throw new NotImplementedException();
        }

        public Task Rollback()
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
