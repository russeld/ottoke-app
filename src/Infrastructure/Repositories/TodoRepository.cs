using Ardalis.Specification;
using Buna.SharedKernel;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TodoRepository<Todo> : RepositoryBase<Todo>, IReadRepository<Todo>, IRepository<Todo> where Todo : class, IAggregateRoot
{
    public TodoRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
