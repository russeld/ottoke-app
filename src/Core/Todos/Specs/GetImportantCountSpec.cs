using Ardalis.Specification;
using Core.Todos.Entities;

namespace Core.Todos.Specs;

public class GetImportantCountSpec : Specification<Todo>
{
    public GetImportantCountSpec(string applicationUserId)
    {
        Query.Where(todo => todo.IsImportant);
        Query.Where(todo => !todo.IsCompleted);
        Query.Where(todo => !todo.IsArchived);
        Query.Where(todo => todo.ApplicationUserId == applicationUserId);
    }
}
