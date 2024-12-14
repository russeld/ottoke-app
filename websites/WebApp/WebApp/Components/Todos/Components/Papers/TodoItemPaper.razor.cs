using Application.Todos.Commands.UpdateTodoCommand;
using Core.Todos.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebApp.States;

namespace WebApp.Components.Todos.Components.Papers;

public partial class TodoItemPaper : ComponentBase
{
    [Inject]
    public ITodoAppState? TodoAppState { get; set; }

    [Inject]
    public IMediator? Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; } = default!;

    [Parameter]
    public string ApplicationUserId { get; set; }

    [Parameter]
    public Todo? Todo { get; set; } = default!;

    [Parameter]
    public EventCallback<Todo> OnDelete { get; set; }

    [Parameter]
    public EventCallback<Todo> OnEdit { get; set; }

    private async Task ToggleComplete(bool isCompleted)
    {
        Todo!.IsCompleted = isCompleted;
        Todo!.UpdatedAt = DateTime.UtcNow;

        if (Todo!.IsCompleted)
        {
            Todo!.DateCompleted = DateTime.UtcNow;
        }
        else
        {
            Todo!.DateCompleted = null;
        }

        var result = await Mediator!.Send(new UpdateTodoCommand(Todo!, ApplicationUserId));
        if (result.IsSuccess)
        {
            Snackbar.Add("Todo completed", Severity.Success);
            TodoAppState!.Remove(Todo!);
        }
    }

    private async Task OnClickEdit()
    {
        await OnEdit.InvokeAsync(Todo);
    }

    private async Task OnClickDelete()
    {
        await OnDelete.InvokeAsync(Todo);
    }
}
