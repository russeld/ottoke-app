using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;
using Core.Habits.Specs;

namespace Application.Habits.Commands.DeleteHabit;

public class DeleteHabitCommandHandler : ICommandHandler<DeleteHabitCommand, Result>
{
    private IRepository<Habit> _habitRepo;

    public DeleteHabitCommandHandler(IRepository<Habit> habitRepo)
    {
        _habitRepo = habitRepo;
    }

    public async Task<Result> Handle(DeleteHabitCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new GetHabitSpec(request.HabitId, request.ApplicationId);

            var habit = await _habitRepo.FirstOrDefaultAsync(spec, cancellationToken);

            if (habit == null)
            {
                return Result.Error("Habit not found.");
            }

            habit.IsArchived = true;

            await _habitRepo.UpdateAsync(habit, cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
