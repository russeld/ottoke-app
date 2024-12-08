using Application.Todos.Commands.Delete;
using Core.Todos.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebApp.Components.Todos.Components.Dialogs;

public partial class DeleteTodoDialog : ComponentBase
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
    public Todo TodoModel { get; set; }

    private void OnClickCancel()
    {
        MudDialog.Cancel();
    }

    private async Task OnClickDeleteTodo()
    {
        var result = await Mediator.Send(new DeleteTodoCommand(TodoModel.Id, ApplicationUserId));
        if (result.IsSuccess)
        {
            Snackbar.Add("Todo deleted successfully", Severity.Success);
            MudDialog.Close(DialogResult.Ok(true));
        }
        else
        {
            Snackbar.Add($"{result.Errors.First()}", Severity.Error);
        }
    }
}
