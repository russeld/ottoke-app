using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;
using Core.Labels.Specs;

namespace Application.Labels.Queries.GetLabels;

public class GetLabelsQueryHandler : IQueryHandler<GetLabelsQuery, Result<List<Label>>>
{
    private readonly IRepository<Label> _repo;

    public GetLabelsQueryHandler(IRepository<Label> repo)
    {
        _repo = repo;
    }

    public async Task<Result<List<Label>>> Handle(GetLabelsQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var spec = new GetLabelListSpec(query.ApplicationUserId);
            var labels = await _repo.ListAsync(spec, cancellationToken);
            return Result.Success(labels);
        }
        catch (Exception e)
        {
            return Result.Error(e.Message);
        }
    }
}
