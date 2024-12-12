using Ardalis.Specification;
using Core.Todos.Entities;

namespace Core.Todos.Specs;

public class GetCompletedTodosSpec : Specification<Todo>
{
    public GetCompletedTodosSpec(string applicationUserId)
    {
        Query.Where(todo => todo.ApplicationUserId == applicationUserId);
        Query.Where(todo => todo.IsCompleted);
        Query.Where(todo => !todo.IsArchived);
        Query.OrderBy(t => t.IsCompleted)
             .ThenByDescending(t => t.IsImportant)
             .ThenByDescending(t => t.Urgency);
    }
}
