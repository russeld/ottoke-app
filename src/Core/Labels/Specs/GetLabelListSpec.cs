using Ardalis.Specification;
using Core.Labels.Entities;

namespace Core.Labels.Specs;

public class GetLabelListSpec : Specification<Label>
{

    public GetLabelListSpec(string applicationUserId)
    {
        Query.AsNoTracking()
             //.Include(l => l.Todos.Where(t => !t.IsCompleted))
             .Where(l => l.ApplicationUserId == applicationUserId);
    }
}
