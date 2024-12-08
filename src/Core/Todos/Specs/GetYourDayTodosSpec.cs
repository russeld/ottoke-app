using Ardalis.Specification;
using Core.Todos.Entities;

namespace Core.Todos.Specs;

public class GetYourDayTodosSpec : Specification<Todo>
{
    public GetYourDayTodosSpec(string applicationUserId)
    {
        Query.Where(todo => todo.ApplicationUserId == applicationUserId);
        Query.Where(todo => todo.DueDate == DateTime.Today.Date);
        Query.Where(todo => !todo.IsDeleted);
        Query.OrderBy(t => t.IsCompleted)
             .ThenByDescending(t => t.IsImportant)
             .ThenByDescending(t => t.Urgency);
    }
}
