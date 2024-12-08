using Buna.SharedKernel;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public Repository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
