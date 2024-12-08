using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Commands.DeleteLabel;

public class DeleteLabelCommandHandler : ICommandHandler<DeleteLabelCommand, Result>
{
    private readonly IRepository<Label> _repo;

    public DeleteLabelCommandHandler(IRepository<Label> repo)
    {
        _repo = repo;
    }

    public async Task<Result> Handle(DeleteLabelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var folder = await _repo.GetByIdAsync(request.Id);

            if (folder == null)
            {
                return Result.Error("Folder not found");
            }

            if (folder.ApplicationUserId != request.ApplicationUserId)
            {
                return Result.Error("You are not authorized to delete this folder");
            }

            await _repo.DeleteAsync(folder, cancellationToken);

            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Error(e.Message);
        }
    }
}
