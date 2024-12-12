using Buna.Result;
using Buna.SharedKernel;
using Core.Habits.Entities;

namespace Application.Habits.Queries.GetHabits;

public class GetHabitsQueryHandler : IQueryHandler<GetHabitsQuery, Result<Habit>>
{
    private readonly IRepository<Habit> _habitRepo;

    public GetHabitsQueryHandler(IRepository<Habit> habitRepo)
    {
        _habitRepo = habitRepo;
    }

    public Task<Result<Habit>> Handle(GetHabitsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
