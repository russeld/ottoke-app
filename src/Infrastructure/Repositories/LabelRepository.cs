using Buna.SharedKernel;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LabelRepository<Label> : RepositoryBase<Label>, IReadRepository<Label>, IRepository<Label> where Label : class, IAggregateRoot
{
    private readonly AppDbContext _dbContext;

    public LabelRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
