using Ardalis.GuardClauses;
using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Commands.Delete;

public class DeleteTodoCommandHandler : ICommandHandler<DeleteTodoCommand, Result>
{
    private readonly IRepository<Todo> _repo;

    public DeleteTodoCommandHandler(IRepository<Todo> repo)
    {
        _repo = repo;
    }

    public async Task<Result> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Guard.Against.Null(command, nameof(command));

            var todo = await _repo.GetByIdAsync(command.TodoId, cancellationToken);

            if (todo == null || todo.ApplicationUserId != command.ApplicationUserId)
            {
                return Result.Error("Todo not found.");
            }

            await _repo.DeleteAsync(todo, cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
