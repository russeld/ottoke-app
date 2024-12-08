using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Commands.UpdateTodoCommand;

public record UpdateTodoCommand(Todo Todo, string ApplicationUserId) : ICommand<Result<Todo>>;
