using Ardalis.Specification;
using Core.Todos.Entities;

namespace Core.Todos.Specs;

public class GetInboxTodosSpec : Specification<Todo>
{
    public GetInboxTodosSpec(string applicationUserId)
    {
        Query.AsNoTracking().Include(t => t.Label);
        Query.Where(todo => todo.ApplicationUserId == applicationUserId && !todo.IsCompleted);
        Query.Where(todo => !todo.IsArchived);
        Query.OrderBy(t => t.IsCompleted)
             .ThenBy(t => t.DueDate)
             .ThenByDescending(t => t.IsImportant)
             .ThenByDescending(t => t.Urgency);
    }
}
