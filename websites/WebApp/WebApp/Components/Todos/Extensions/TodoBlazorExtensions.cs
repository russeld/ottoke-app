using Core.Todos.Entities;
using Core.Todos.Enums;
using MudBlazor;

namespace WebApp.Components.Todos.Extensions;

public static class TodoBlazorExtensions
{
    public static Color IconImportanceColor(this Todo todo)
    {
        return todo.IsImportant switch
        {
            true => Color.Error,
            false => Color.Default
        };
    }

    public static Variant UrgencyButtonVariant(this Todo todo, TodoUrgency urgency)
    {
        return todo.Urgency == urgency ? Variant.Filled : Variant.Outlined;
    }
}
