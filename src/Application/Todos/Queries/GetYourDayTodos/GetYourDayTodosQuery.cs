using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Queries.GetYourDayTodos;

public record GetYourDayTodosQuery(string ApplicationUserId) : IQuery<Result<List<Todo>>>;
