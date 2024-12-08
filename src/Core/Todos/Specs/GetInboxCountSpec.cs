using Ardalis.Specification;
using Core.Todos.Entities;

namespace Core.Todos.Specs;

public class GetInboxCountSpec : Specification<Todo>
{
    public GetInboxCountSpec(string applicationUserId)
    {
        Query.Where(todo => todo.Label == null);
        Query.Where(todo => todo.ApplicationUserId == applicationUserId);
    }
}
