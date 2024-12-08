using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;
using Core.Labels.Specs;
using Core.Todos.Entities;

namespace Application.Labels.Queries.GetLabelTodos;

public class GetLabelTodosQueryHandler : IQueryHandler<GetLabelTodosQuery, Result<Label>>
{
    private readonly IRepository<Label> _repo;

    public GetLabelTodosQueryHandler(IRepository<Label> repo)
    {
        _repo = repo;
    }

    public async Task<Result<Label>> Handle(GetLabelTodosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new GetLabelWithTodoSpec(request.Id, request.ApplicationUserId);
            var folder = await _repo.FirstOrDefaultAsync(spec, cancellationToken);

            if (folder == null) return Result.NotFound();

            return Result.Success(folder);
        }
        catch (Exception e)
        {
            return Result.Error(e.Message);
        }
    }
}
