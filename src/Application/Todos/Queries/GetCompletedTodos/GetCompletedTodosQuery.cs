using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Queries.GetCompletedTodos;

public record GetCompletedTodosQuery(string ApplicationUserId) : IQuery<Result<IEnumerable<Todo>>>;
