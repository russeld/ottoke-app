using Core.Todos.Enums;
using Core.Todos.Models;
using MudBlazor;

namespace WebApp.Components.Todos.Extensions;

public static class TodoInputModelExtensions
{
    public static Variant UrgencyButtonVariant(this CreateTodoInputModel inputModel, TodoUrgency urgency)
    {
        return inputModel.Urgency == urgency ? Variant.Filled : Variant.Outlined;
    }
}
