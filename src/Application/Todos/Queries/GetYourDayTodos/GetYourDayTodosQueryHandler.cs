using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;
using Core.Todos.Specs;

namespace Application.Todos.Queries.GetYourDayTodos;

public class GetYourDayTodosQueryHandler : IQueryHandler<GetYourDayTodosQuery, Result<List<Todo>>>
{
    private IRepository<Todo> _todoRepo;

    public GetYourDayTodosQueryHandler(IRepository<Todo> todoRepo)
    {
        _todoRepo = todoRepo;
    }

    public async Task<Result<List<Todo>>> Handle(GetYourDayTodosQuery request, CancellationToken cancellationToken)
    {
        var yourDaySpec = new GetYourDayTodosSpec(request.ApplicationUserId);
        var todos = await _todoRepo.ListAsync(yourDaySpec, cancellationToken);
        return Result.Success(todos);
    }
}
