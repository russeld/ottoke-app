using Ardalis.GuardClauses;
using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;

namespace Application.Todos.Commands.Create;

public class CreateTodoCommandHandler(IRepository<Todo> repository) : ICommandHandler<CreateTodoCommand, Result<Todo>>
{
    private readonly IRepository<Todo> _repository = repository;

    public async Task<Result<Todo>> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        Guard.Against.Null(command, nameof(command));

        var input = command.Input;

        try
        {
            var todo = new Todo
            {
                Title = input.Title,
                DueDate = input.DueDate,
                Urgency = input.Urgency,
                IsImportant = input.IsImportant,
                Description = input.Description,
                ApplicationUserId = command.ApplicationUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            if (input.Label != null)
            {
                todo.LabelId = input.Label.Id;
            }

            await _repository.AddAsync(todo, cancellationToken);

            return Result.Success(todo);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
