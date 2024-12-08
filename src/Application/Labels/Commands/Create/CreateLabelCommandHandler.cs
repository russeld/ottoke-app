using Buna.Result;
using Buna.SharedKernel;
using Core.Labels.Entities;

namespace Application.Labels.Commands.Create;

public class CreateLabelCommandHandler : ICommandHandler<CreateLabelCommand, Result<Label>>
{
    private readonly IRepository<Label> _repository;

    public CreateLabelCommandHandler(IRepository<Label> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Label>> Handle(CreateLabelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var label = new Label
            {
                Title = request.Title,
                Slug = request.Title.Trim().ToLower(),
                Color = "#000000",
                ApplicationUserId = request.ApplicationUserId,
                CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            };

            await _repository.AddAsync(label, cancellationToken);

            return Result.Success(label);
        }
        catch (Exception e)
        {
            return Result.Error(e.Message);
        }
    }
}
