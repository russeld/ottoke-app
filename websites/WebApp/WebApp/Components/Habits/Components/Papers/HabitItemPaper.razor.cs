using Core.Habits.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebApp.Components.Habits.Components.Dialogs;
using WebApp.States;

namespace WebApp.Components.Habits.Components.Papers;

public partial class HabitItemPaper : ComponentBase, IDisposable
{
    // cascade parameter

    // inject
    [Inject]
    public IHabitTrackerAppState HabitAppState { get; set; } = default!;

    [Inject]
    public IMediator Mediator { get; set; } = default!;

    [Inject]
    public IDialogService DialogService { get; set; } = default!;

    // parameter
    [Parameter]
    public Habit Habit { get; set; } = default!;

    [Parameter]
    public string ApplicationUserId { get; set; } = string.Empty;

    [Parameter]
    public EventHandler OnDelete { get; set; } = default!;
    
    [Parameter]
    public EventHandler OnEdit { get; set; } = default!;


    protected override async Task OnInitializedAsync()
    {
        HabitAppState.OnChange += StateHasChanged;
        await base.OnInitializedAsync();
    }

    private async Task OnClickEdit()
    {
        var parameters = new DialogParameters() { { "Habit", Habit }, { "ApplicationUserId", ApplicationUserId } };
        var options = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, Position = DialogPosition.TopCenter };
        await DialogService.ShowAsync<EditHabitDialog>("Edit Habit", parameters, options);
    }

    private void OnClickDelete()
    {

    }

    public void Dispose()
    {
        HabitAppState.OnChange -= StateHasChanged;
    }
}
