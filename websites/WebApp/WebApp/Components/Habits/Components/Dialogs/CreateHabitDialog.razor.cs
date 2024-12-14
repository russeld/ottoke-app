using Application.Habits.Commands.CreateHabit;
using Core.Habits.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebApp.Components.Habits.Components.Dialogs;

public partial class CreateHabitDialog : ComponentBase
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    [Inject]
    public IDialogService DialogService { get; set; } = default!;

    [Inject]
    public IMediator Mediator { get; set; } = default!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = default!;

    [Parameter]
    public string ApplicationUserId { get; set; } = string.Empty;

    private readonly CreateHabitInputModel InputModel = new();

    private void OnClickCancel()
    {
        MudDialog.Cancel();
    }

    private async Task OnClickCreate()
    {
        var result = await Mediator.Send(new CreateHabitCommand(InputModel, ApplicationUserId));

        if (result.IsSuccess)
        {
            Snackbar.Add("Habit created successfully", Severity.Success);
            MudDialog.Close(DialogResult.Ok(result.Value));
        }
        else
        {
            Snackbar.Add("Failed to create habit", Severity.Error);
        }
    }
}
