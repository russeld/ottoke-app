﻿using Application.Todos.Queries.GetYourDayTodos;
using Core.Todos.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebApp.Components.Todos.Components.Cards;

public partial class YourDayTodoCard : ComponentBase
{
    // cascading parameter
    [CascadingParameter]
    public Task<AuthenticationState>? authenticationState { get; set; }

    // inject
    [Inject]
    public IMediator Mediator { get; set; }

    // private
    private string applicationUserId = string.Empty;

    private List<Todo> todoList = new();

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
            todoList = result.Value;
        }
    }
}
