using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;
using Core.Todos.Entities;

namespace Application.Labels.Queries.GetLabelTodos;

public record GetLabelTodosQuery(int Id, string ApplicationUserId) : IQuery<Result<Label>>;
