using Application.Habits.Queries.GetHabits;
using Core.Habits.Entities;
using Core.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Security.Claims;
using WebApp.Components.Habits.Components.Dialogs;
using WebApp.States;

namespace WebApp.Components.Habits.Components.Pages;

public partial class HabitTrackerApp : ComponentBase, IDisposable
{
    [CascadingParameter]
    public Task<AuthenticationState>? AuthenticationState { get; set; }


    [Inject]
    public IHabitTrackerAppState HabitAppState { get; set; } = default!;

    [Inject]
    public IMediator Mediator { get; set; } = default!;

    [Inject]
    public IDialogService DialogService { get; set; } = default!;

    private string applicationUserId = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (AuthenticationState is not null)
        {
            var authState = await AuthenticationState;
            var user = authState?.User;
            if (user is not null)
            {
                applicationUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

                await GetHabits();
            }
        }

        HabitAppState!.OnChange += StateHasChanged;

        await base.OnInitializedAsync();
    }

    private async Task GetHabits()
    {
        var result = await Mediator.Send(new GetHabitsQuery(applicationUserId));

        if (result.IsSuccess)
        {
            HabitAppState.SetHabits(result.Value);
        }
    }

    private async Task OnClickCreateHabit()
    {
        var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, Position = DialogPosition.TopCenter };
        var parameters = new DialogParameters<CreateHabitDialog> {
            { "ApplicationUserId", applicationUserId }
        };
        var dialog = DialogService.Show<CreateHabitDialog>("Create Habit", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            HabitAppState.AddHabit(result.Data as Habit);
        }
    }

    public void Dispose()
    {
        HabitAppState.OnChange -= StateHasChanged;
    }
}
