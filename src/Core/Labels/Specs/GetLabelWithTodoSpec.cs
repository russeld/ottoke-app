using Ardalis.Specification;
using Core.Labels.Entities;

namespace Core.Labels.Specs;

public class GetLabelWithTodoSpec : Specification<Label>
{
    public GetLabelWithTodoSpec(int id, string applicationUserId)
    {
        Query.AsNoTracking()
             .Where(f => f.Id == id)
             .Where(f => f.ApplicationUserId == applicationUserId)
             .Include(f => f.Todos.Where(t => !t.IsCompleted)
                                .OrderBy(t => t.IsCompleted)
                                .ThenByDescending(t => t.IsImportant)
                                .ThenByDescending(t => t.Urgency));
    }
}
