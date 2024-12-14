using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;
using Core.Habits.Specs;

namespace Application.Habits.Queries.GetHabits;

public class GetHabitsQueryHandler : IQueryHandler<GetHabitsQuery, Result<List<Habit>>>
{
    private readonly IRepository<Habit> _habitRepo;

    public GetHabitsQueryHandler(IRepository<Habit> habitRepo)
    {
        _habitRepo = habitRepo;
    }

    public async Task<Result<List<Habit>>> Handle(GetHabitsQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new GetHabitsSpec(query.ApplicationUserId);
            var habits = await _habitRepo.ListAsync(spec, cancellationToken);
            return Result.Success(habits);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
