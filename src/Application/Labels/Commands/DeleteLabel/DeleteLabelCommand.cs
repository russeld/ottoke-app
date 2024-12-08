using Buna.Result;
using Buna.SharedKernel;

namespace Application.Labels.Commands.DeleteLabel;

public record DeleteLabelCommand(int Id, string ApplicationUserId) : ICommand<Result>;
