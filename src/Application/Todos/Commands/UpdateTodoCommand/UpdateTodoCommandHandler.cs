using Ardalis.GuardClauses;
using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Commands.UpdateTodoCommand;

public class UpdateTodoCommandHandler : ICommandHandler<UpdateTodoCommand, Result<Todo>>
{
    private readonly IRepository<Todo> _repo;

    public UpdateTodoCommandHandler(IRepository<Todo> repo)
    {
        _repo = repo;
    }

    public async Task<Result<Todo>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request.Todo, nameof(request.Todo));

        try
        {
            var todo = await _repo.GetByIdAsync(request.Todo.Id, cancellationToken);

            if (todo == null)
            {
                return Result.Error("Todo not found.");
            }

            if (todo.ApplicationUserId != request.ApplicationUserId)
            {
                return Result.Error("Todo not found.");
            }

            todo.Title = request.Todo.Title;
            todo.IsCompleted = request.Todo.IsCompleted;
            todo.Description = request.Todo.Description;
            todo.DueDate = request.Todo.DueDate;
            todo.UpdatedAt = DateTime.UtcNow;
            todo.Urgency = request.Todo.Urgency;
            todo.IsImportant = request.Todo.IsImportant;

            if (request.Todo.Label != null)
            {
                todo.LabelId = request.Todo.Label.Id;
            }
            else
            {
                todo.LabelId = null;
            }

            await _repo.SaveChangesAsync(cancellationToken);

            return Result.Success(todo);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
