using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;

namespace Application.Habits.Commands.EditHabit;

public class EditHabitCommandHandler : ICommandHandler<EditHabitCommand, Result<Habit>>
{
    private readonly IRepository<Habit> _habitRepo;

    public EditHabitCommandHandler(IRepository<Habit> habitRepo)
    {
        _habitRepo = habitRepo;
    }

    public async Task<Result<Habit>> Handle(EditHabitCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var habit = await _habitRepo.GetByIdAsync(command.Habit.Id);

            if (habit == null || habit.ApplicationUserId != command.ApplicationUserId)
            {
                return Result.Error($"Habit with id {command.Habit.Id} not found.");
            }

            habit.Name = command.Habit.Name;
            habit.Description = command.Habit.Description;
            habit.Frequency = command.Habit.Frequency;
            habit.UpdatedAt = DateTime.UtcNow;

            await _habitRepo.UpdateAsync(habit, cancellationToken);
            return Result.Success(habit);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
