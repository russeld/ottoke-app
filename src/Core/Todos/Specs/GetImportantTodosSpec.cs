using Ardalis.Specification;
using Core.Todos.Entities;

namespace Core.Todos.Specs;

public class GetImportantTodosSpec : Specification<Todo>
{
    public GetImportantTodosSpec(string applicationUserId)
    {
        Query.AsNoTracking()
             .Include(t => t.Label)
             .Where(todo => todo.ApplicationUserId == applicationUserId && todo.IsImportant && !todo.IsCompleted);
        Query.Where(todo => !todo.IsDeleted);
        Query.OrderBy(t => t.IsCompleted)
             .ThenByDescending(t => t.IsImportant)
             .ThenByDescending(t => t.Urgency);
    }
}
