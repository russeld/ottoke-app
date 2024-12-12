using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Commands.EditLabel;

public class EditLabelCommandHandler : ICommandHandler<EditLabelCommand, Result>
{
    private readonly IRepository<Label> _repo;

    public EditLabelCommandHandler(IRepository<Label> repo)
    {
        _repo = repo;
    }

    public async Task<Result> Handle(EditLabelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var folder = await _repo.GetByIdAsync(request.Label.Id);

            if (folder == null)
            {
                return Result.Error("Folder not found");
            }

            if (folder.ApplicationUserId != request.ApplicationUserId)
            {
                return Result.Error("You are not authorized to edit this folder");
            }

            folder.Title = request.Label.Title;
            folder.Color = request.Label.Color;
            folder.Icon = request.Label.Icon;
            folder.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);

            await _repo.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Error(e.Message);
        }
    }
}
