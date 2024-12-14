using Application.Habits.Commands.EditHabit;
using Core.Habits.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebApp.States;

namespace WebApp.Components.Habits.Components.Dialogs;

public partial class EditHabitDialog : ComponentBase
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; } = default!;


    [Inject]
    public ISnackbar Snackbar { get; set; } = default!;

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public IHabitTrackerAppState HabitAppState { get; set; } = default!;

    [Parameter]
    public Habit HabitModel { get; set; } = default!;

    [Parameter]
    public string ApplicationUserId { get; set; }

    private void OnClickCancel()
    {
        MudDialog.Cancel();
    }

    private async Task OnClickSave()
    {
        try
        {
            var result = await Mediator.Send(new EditHabitCommand(HabitModel, ApplicationUserId));
            if (result.IsSuccess)
            {
                HabitAppState.UpdateHabit(HabitModel);
                Snackbar.Add("Habit updated successfully", Severity.Success);
                MudDialog.Close();
            }
            else
            {
                Snackbar.Add("Failed to update habit", Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}
