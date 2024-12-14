using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;
using Core.Habits.Specs;

namespace Application.Habits.Queries.GetYourDayHabits;

public class GetYourDayHabitsQueryHandler : IQueryHandler<GetYourDayHabitsQuery, Result<List<Habit>>>
{
    private readonly IRepository<Habit> _habitRepo;

    public GetYourDayHabitsQueryHandler(IRepository<Habit> habitRepo)
    {
        _habitRepo = habitRepo;
    }

    /// <summary>
    /// Handles the GetYourDayHabitsQuery to retrieve a list of habits for a specific user.
    /// </summary>
    /// <param name="request">The query request containing the ApplicationUserId.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A Result object containing a list of Habit objects or an error message.</returns>
    public async Task<Result<List<Habit>>> Handle(GetYourDayHabitsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new GetYourDayHabitsSpec(request.ApplicationUserId);
            var habits = await _habitRepo.ListAsync(spec, cancellationToken);
            return Result.Success(habits);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
