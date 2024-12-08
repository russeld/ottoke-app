using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Queries.GetImportantTodos;

public record GetImportantTodosQuery(string ApplicationUserId) : IQuery<Result<IEnumerable<Todo>>>;
