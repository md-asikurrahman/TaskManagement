using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;

        public void Dispose() => _dbContext?.Dispose();
        public void Save()
        {
            bool hasChanges = _dbContext.ChangeTracker.HasChanges();
            _dbContext?.SaveChanges();
        }
    }

}
