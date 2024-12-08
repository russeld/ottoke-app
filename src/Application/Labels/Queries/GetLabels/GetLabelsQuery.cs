using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Queries.GetLabels;

public record GetLabelsQuery(string ApplicationUserId) : IQuery<Result<List<Label>>>;
