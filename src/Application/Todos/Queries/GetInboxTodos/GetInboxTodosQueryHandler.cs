using Ardalis.GuardClauses;
using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;
using Core.Todos.Specs;

namespace Application.Todos.Queries.GetInboxTodos;

public class GetInboxTodosQueryHandler : IQueryHandler<GetInboxTodosQuery, Result<IEnumerable<Todo>>>
{
    private readonly IRepository<Todo> _repo;

    public GetInboxTodosQueryHandler(IRepository<Todo> repo)
    {
        _repo = repo;
    }

    public async Task<Result<IEnumerable<Todo>>> Handle(GetInboxTodosQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request, nameof(request));

        var spec = new GetInboxTodosSpec(request.ApplicationUserId);
        var todos = await _repo.ListAsync(spec, cancellationToken);

        return Result<IEnumerable<Todo>>.Success(todos);
    }
}
