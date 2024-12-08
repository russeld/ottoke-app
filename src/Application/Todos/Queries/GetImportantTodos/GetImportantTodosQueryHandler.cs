using Ardalis.GuardClauses;
using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;
using Core.Todos.Specs;

namespace Application.Todos.Queries.GetImportantTodos;

public class GetImportantTodosQueryHandler : IQueryHandler<GetImportantTodosQuery, Result<IEnumerable<Todo>>>
{
    private readonly IRepository<Todo> _repo;

    public GetImportantTodosQueryHandler(IRepository<Todo> repo)
    {
        _repo = repo;
    }

    public async Task<Result<IEnumerable<Todo>>> Handle(GetImportantTodosQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request, nameof(request));

        try 
        {
            var spec = new GetImportantTodosSpec(request.ApplicationUserId);
            var todos = await _repo.ListAsync(spec, cancellationToken);
            return Result<IEnumerable<Todo>>.Success(todos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<Todo>>.Error(ex.Message);
        }
    }
}
