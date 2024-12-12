using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;
using Core.Habits.Enums;

namespace Application.Habits.Commands;

public class CreateHabitCommandHandler : ICommandHandler<CreateHabitCommand, Result<Habit>>
{
    private readonly IRepository<Habit> _habitRepo;

    public CreateHabitCommandHandler(IRepository<Habit> habitRepo)
    {
        _habitRepo = habitRepo;
    }

    public async Task<Result<Habit>> Handle(CreateHabitCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var habit = new Habit
            {
                Name = command.InputModel.Name,
                Description = command.InputModel.Description,
                Frequency = command.InputModel.Frequency,
                ApplicationUserId = command.ApplicationUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _habitRepo.AddAsync(habit, cancellationToken);

            return Result<Habit>.Success(habit);
        }
        catch (Exception ex)
        {
            return Result<Habit>.Error(ex.Message);
        }
    }
}
