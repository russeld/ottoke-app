using Ardalis.Specification;
using Core.Habits.Entities;

namespace Core.Habits.Specs;

public class GetHabitSpec : Specification<Habit>
{
    public GetHabitSpec(int habitId, string applicationUserId)
    {
        Query.AsNoTracking()
             .Where(h => h.Id == habitId)
             .Where(h => h.ApplicationUserId == applicationUserId);
    }
}
