using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Commands.EditLabel;

public record EditLabelCommand(Label Folder, string ApplicationUserId) : ICommand<Result>;
