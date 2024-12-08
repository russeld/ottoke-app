using Buna.Result;
using Buna.SharedKernel;

namespace Application.Todos.Commands.Delete;

public record DeleteTodoCommand(int TodoId, string ApplicationUserId) : ICommand<Result>;
