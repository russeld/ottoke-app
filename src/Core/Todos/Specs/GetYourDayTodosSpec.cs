using Ardalis.Specification;
using Core.Todos.Entities;

namespace Core.Todos.Specs;

public class GetYourDayTodosSpec : Specification<Todo>
{
    public GetYourDayTodosSpec(string applicationUserId)
    {
        Query.AsNoTracking().Include(t => t.Label);
        Query.Where(todo => todo.ApplicationUserId == applicationUserId);
        Query.Where(todo => todo.DueDate == DateTime.Today.Date);
        Query.Where(todo => !todo.IsArchived);
        Query.OrderBy(t => t.IsCompleted)
             .ThenBy(t => t.DueDate)
             .ThenByDescending(t => t.IsImportant)
             .ThenByDescending(t => t.Urgency);
    }
}
