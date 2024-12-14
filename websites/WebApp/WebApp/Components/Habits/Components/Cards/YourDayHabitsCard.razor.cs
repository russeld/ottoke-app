using Application.Habits.Queries.GetYourDayHabits;
using Core.Habits.Entities;
using Core.Todos.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebApp.Components.Habits.Components.Cards;

public partial class YourDayHabitsCard : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public Task<AuthenticationState>? authenticationState { get; set; }

    private string applicationUserId = string.Empty;

    private List<Habit> habitList = [];

    protected async override Task OnInitializedAsync()
    {
        if (authenticationState is not null)
        {
            var authState = await authenticationState;
            var user = authState?.User;
            if (user is not null)
            {
                applicationUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                await LoadHabits();
            }
        }
        await base.OnInitializedAsync();
    }

    private async Task LoadHabits()
    {
        var query = new GetYourDayHabitsQuery(applicationUserId);
        var result = await Mediator.Send(query);
        if (result.IsSuccess)
        {
            habitList = result.Value;
        }
    }
}
