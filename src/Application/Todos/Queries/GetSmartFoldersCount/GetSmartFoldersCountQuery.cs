using Buna.Result;
using Buna.SharedKernel;
using Core.Todos.Models;

namespace Application.Todos.Queries.GetSmartFoldersCount;

public record GetSmartFoldersCountQuery(string ApplicationUserId) : IQuery<Result<SmartFolderCount>>;

