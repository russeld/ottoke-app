using Ardalis.Specification;
using Core.Habits.Entities;

namespace Core.Habits.Specs;

public class GetHabitsSpec : Specification<Habit>
{
    public GetHabitsSpec(string applicationUserId)
    {
        Query.AsNoTracking()
             .Where(x => x.ApplicationUserId == applicationUserId)
             .Where(x => x.IsArchived == false);
    }
}
