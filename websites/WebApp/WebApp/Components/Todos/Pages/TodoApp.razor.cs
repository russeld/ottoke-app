using Application.Labels.Queries.GetLabels;
using Application.Todos.Queries.GetInboxTodos;
using Core.Todos.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Security.Claims;
using WebApp.Components.Todos.Components.Dialogs;
using WebApp.States;

namespace WebApp.Components.Todos.Pages;

public partial class TodoApp : ComponentBase, IDisposable
{
    [CascadingParameter]
    public Task<AuthenticationState>? AuthenticationState { get; set; }

    [Inject]
    public ITodoAppState? TodoAppState { get; set; }

    [Inject]
    public IMediator? Mediator { get; set; }

    [Inject]
    public IDialogService? DialogService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; } = default!;

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

                await GetUserTasks();
                await GetUserLabels();
            }
        }

        TodoAppState!.OnChange += StateHasChanged;

        await base.OnInitializedAsync();
    }

    private async Task OnClickCreateTodo()
    {
        var parameters = new DialogParameters<CreateTodoDialog> { 
            { "ApplicationUserId", applicationUserId }, 
            { "Labels", TodoAppState!.Labels }
        };

        var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true, Position = DialogPosition.TopCenter };
        var dialog = await DialogService!.ShowAsync<CreateTodoDialog>("Create Todo", parameters, options);
        var result = await dialog.Result;

        if (!result!.Canceled)
        {
            var todo = result.Data as Todo;
            if (todo is not null)
            {
                TodoAppState!.Add(todo);
            }
        }
    }

    private async Task OnEditTodo(Todo todo)
    {
        var parameters = new DialogParameters<EditTodoDialog> {
            { "ApplicationUserId", applicationUserId },
            { "Labels", TodoAppState!.Labels },
            { "TodoModel", todo }
        };
        var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true, Position = DialogPosition.TopCenter };
        var dialog = await DialogService!.ShowAsync<EditTodoDialog>("Edit Todo", parameters, options);
        var result = await dialog.Result;
        if (!result!.Canceled)
        {
            var updatedTodo = result.Data as Todo;
            if (updatedTodo is not null)
            {
                TodoAppState!.Update(updatedTodo);
            }
        }
    }

    private async Task OnDeleteTodo(Todo todo)
    {
        var parameters = new DialogParameters<DeleteTodoDialog> { { "TodoModel", todo }, { "ApplicationUserId", applicationUserId } };
        var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true, Position = DialogPosition.TopCenter };
        var dialog = await DialogService!.ShowAsync<DeleteTodoDialog>("Delete Todo", parameters, options);
        var result = await dialog.Result;
       Console.WriteLine($"Todo deleted successfully {result!.Canceled}");
        if (!result!.Canceled)
        {
            TodoAppState!.Remove(todo);
        }
    }

    private async Task GetUserTasks()
    {
        var result = await Mediator!.Send(new GetInboxTodosQuery(applicationUserId));
        if (result.IsSuccess)
        {
            TodoAppState!.SetTodos(result.Value.ToList());
        }
    }

    private async Task GetUserLabels()
    {
        var result = await Mediator!.Send(new GetLabelsQuery(applicationUserId));
        if (result.IsSuccess)
        {
            TodoAppState!.SetLabels(result.Value.ToList());
        }
    }

    public void Dispose()
    {
        TodoAppState!.OnChange -= StateHasChanged;
    }
}
