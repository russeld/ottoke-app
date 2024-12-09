using Application.Todos.Queries.GetYourDayTodos;
using Core.Todos.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebApp.Components.Todos.Components.Cards;

public partial class YourDayTodoCard : ComponentBase
{
    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public Task<AuthenticationState>? authenticationState { get; set; }

    private string applicationUserId = string.Empty;

    private List<Todo> Todos = new();

    protected async override Task OnInitializedAsync()
    {
        if (authenticationState is not null)
        {
            var authState = await authenticationState;
            var user = authState?.User;
            if (user is not null)
            {
                applicationUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                await LoadTodos();
            }
        }

        await base.OnInitializedAsync();
    }

    private async Task LoadTodos()
    {
        var query = new GetYourDayTodosQuery(applicationUserId);
        var result = await Mediator.Send(query);
        if (result.IsSuccess)
        {
            Todos = result.Value;
        }
    }

    private void OnTodoClick(Todo todo)
    {
        Console.WriteLine($"Todo clicked: {todo.Title}");
    }

    private void OnTodoDelete(Todo todo)
    {
        Todos.Remove(todo);
    }
}
