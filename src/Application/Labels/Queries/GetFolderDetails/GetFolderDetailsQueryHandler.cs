using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Queries.GetFolderDetails;

public class GetFolderDetailsQueryHandler : IQueryHandler<GetFolderDetailsQuery, Result<Label>>
{
    private readonly IRepository<Label> _repo;

    public GetFolderDetailsQueryHandler(IRepository<Label> repo)
    {
        _repo = repo;
    }

    public async Task<Result<Label>> Handle(GetFolderDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var folder = await _repo.GetByIdAsync(request.Id, cancellationToken);

            if (folder == null) return Result.NotFound();

            return Result.Success(folder);
        }
        catch (Exception e)
        {
            return Result.Error(e.Message);
        }
    }
}
