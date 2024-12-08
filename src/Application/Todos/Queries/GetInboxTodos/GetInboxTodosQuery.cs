using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Queries.GetInboxTodos;

public record GetInboxTodosQuery(string ApplicationUserId) : IQuery<Result<IEnumerable<Todo>>>;
