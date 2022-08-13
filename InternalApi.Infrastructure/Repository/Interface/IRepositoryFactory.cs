using InternalApi.Domain.Entities;

namespace InternalApi.Infrastructure.Repository.Interface;

public interface IRepositoryFactory
{
    Task<int> SaveChangesAsync();

    IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
}