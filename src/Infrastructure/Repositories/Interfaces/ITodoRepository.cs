using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface ITodoRepository : IRepository<Todo>
{
    Task<int> GetInboxTodosCount(string applicationUserId);

    Task<int> GetImportantTodosCount(string applicationUserId);
}
