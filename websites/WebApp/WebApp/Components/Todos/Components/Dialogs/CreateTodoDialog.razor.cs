using Application.Labels.Commands.Create;
using Application.Todos.Commands.Create;
using Core.Labels.Entities;
using Core.Todos.Enums;
using Core.Todos.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebApp.Components.Todos.Components.Dialogs;

public partial class CreateTodoDialog : ComponentBase
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; } = default!;

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; } = default!;

    [Parameter]
    public string ApplicationUserId { get; set; }

    [Parameter]
    public List<Label> Labels { get; set; } = [];

    private CreateTodoInputModel InputModel { get; set; }

    protected override void OnInitialized()
    {
        InputModel = new CreateTodoInputModel();
    }

    private void OnClickCancel()
    {
        MudDialog.Cancel();
    }

    private async Task<IEnumerable<Label>> SearchAsync(string value, CancellationToken token)
    {
        await Task.Delay(1, token);

        if (string.IsNullOrEmpty(value))
        {
            return Labels;
        }

        var labels = Labels.Where(x => x.Title.Equals(value, StringComparison.InvariantCultureIgnoreCase)).ToList();

        if (labels.Any())
        {
            return labels;
        }

        return new List<Label>() { new Label { Title = value, Id = 0 } };
    }

    private async Task OnClickCreateTodo()
    {
        var result = await Mediator.Send(new CreateTodoCommand(InputModel, ApplicationUserId));

        if (result.IsSuccess)
        {
            var todo = result.Value;
            todo.Label = Labels.FirstOrDefault(x => x.Id == todo.LabelId);
            MudDialog.Close(DialogResult.Ok(todo));
        }
        else
        {
            Snackbar.Add($"Something went wrong. {result.Errors.First()}", Severity.Error);
        }
    }

    private async Task OnLabelChanged(Label label)
    {
        await OnSelectLabel(label);
    }

    private async Task OnSelectLabel(Label selectedLabel)
    {
        if (selectedLabel != null && selectedLabel.Id == 0)
        {
            var command = new CreateLabelCommand(selectedLabel.Title, ApplicationUserId);
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
            {
                Labels.Add(new Label { Id = result.Value.Id, Title = selectedLabel.Title });
                InputModel.Label = result.Value;
            }
        }
        else
        {
            InputModel.Label = selectedLabel;
        }

        StateHasChanged();
    }
}
