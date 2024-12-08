using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Entities;
using Core.Todos.Models;
using Core.Todos.Specs;

namespace Application.Todos.Queries.GetSmartFoldersCount;

public class GetSmartFolderQueryHandler : IQueryHandler<GetSmartFoldersCountQuery, Result<SmartFolderCount>>
{
    private IRepository<Todo> _todoRepo;

    public GetSmartFolderQueryHandler(IRepository<Todo> todoRepo)
    {
        _todoRepo = todoRepo;
    }

    public async Task<Result<SmartFolderCount>> Handle(GetSmartFoldersCountQuery request, CancellationToken cancellationToken)
    {
        var smartFolderCount = new SmartFolderCount();

        var inboxCountSpec = new GetInboxTodosSpec(request.ApplicationUserId);
        var inboxCount = await _todoRepo.CountAsync(inboxCountSpec);
        smartFolderCount.InboxCount = inboxCount;

        var importantCountSpec = new GetImportantCountSpec(request.ApplicationUserId);
        var importantCount = await _todoRepo.CountAsync(importantCountSpec);
        smartFolderCount.ImportantCount = importantCount;

        return Result.Success(smartFolderCount);
    }
}
