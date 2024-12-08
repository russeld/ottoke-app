using Application.Todos.Queries.GetYourDayTodos;
using Core.Todos.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebApp.Components.Pages;

public partial class YourDay : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public Task<AuthenticationState>? authenticationState { get; set; }

    private const string PageTitle = "Your Day";

    private List<Todo> Todos = [];

    private string ApplicationUserId = string.Empty;

    protected async override Task OnInitializedAsync()
    {
        if (authenticationState is not null)
        {
            var authState = await authenticationState;
            var user = authState?.User;
            if (user is not null)
            {
                ApplicationUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                await LoadTodos();
            }
        }

        await base.OnInitializedAsync();
    }

    private async Task LoadTodos()
    {
        var query = new GetYourDayTodosQuery(ApplicationUserId);
        var result = await Mediator.Send(query);
        if (result.IsSuccess)
        {
            Todos = result.Value;
        }
    }
}
