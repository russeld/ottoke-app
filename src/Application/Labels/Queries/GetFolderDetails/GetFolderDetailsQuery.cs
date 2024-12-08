using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Queries.GetFolderDetails;

public record GetFolderDetailsQuery(int Id, string ApplicationUserId) : IQuery<Result<Label>>;
