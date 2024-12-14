using Ardalis.Specification;
using Core.Habits.Entities;

namespace Core.Habits.Specs;

public class GetYourDayHabitsSpec : Specification<Habit>
{
    public GetYourDayHabitsSpec(string applicationUserId)
    {
        Query.AsNoTracking()
             .Where(x => x.ApplicationUserId == applicationUserId)
             .Where(x => x.IsArchived == false);
    }
}
