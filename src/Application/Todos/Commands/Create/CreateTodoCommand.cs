using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;
using Core.Todos.Models;

namespace Application.Todos.Commands.Create
{
    public record CreateTodoCommand(CreateTodoInputModel Input, string ApplicationUserId) : ICommand<Result<Todo>>;
}
