using Application.Habits.Commands.DeleteHabit;
using Core.Habits.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebApp.States;

namespace WebApp.Components.Habits.Components.Dialogs;

public partial class DeleteHabitDialog : ComponentBase
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    [Inject]
    public IHabitTrackerAppState HabitAppState { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; } = default!;

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; } = default!;

    [Parameter]
    public string ApplicationUserId { get; set; }

    [Parameter]
    public Habit HabitModel { get; set; }

    private void OnClickCancel()
    {
        MudDialog.Cancel();
    }

    private async Task OnClickDelete()
    {
        var result = await Mediator.Send(new DeleteHabitCommand(HabitModel.Id, ApplicationUserId));
        if (result.IsSuccess)
        {
            HabitAppState.RemoveHabit(HabitModel);
            Snackbar.Add("Habit deleted successfully", Severity.Success);
            MudDialog.Close(DialogResult.Ok(true));
        }
        else
        {
            Snackbar.Add($"{result.Errors.First()}", Severity.Error);
        }
    }
}
