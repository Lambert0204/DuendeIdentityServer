using InternalApi.Domain.Entities;
using InternalApi.Infrastructure.Context;
using InternalApi.Infrastructure.Repository;
using InternalApi.Infrastructure.Repository.Interface;

namespace ExerciseTwoApi.Infrastructure.Data.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly InternalContext _dbContext;

        public RepositoryFactory(InternalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}