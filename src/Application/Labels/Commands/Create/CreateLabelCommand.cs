using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Commands.Create;

public record CreateLabelCommand(string Title, string ApplicationUserId) : ICommand<Result<Label>>;
