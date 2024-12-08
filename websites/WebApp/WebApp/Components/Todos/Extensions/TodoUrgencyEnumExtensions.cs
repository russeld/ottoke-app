using Core.Todos.Enums;
using MudBlazor;

namespace Core.Todos.Extensions;

public static class TodoUrgencyEnumExtensions
{
    public static Color IconColor(this TodoUrgency urgency) => urgency switch
    {
        TodoUrgency.Low => Color.Default,
        TodoUrgency.Medium => Color.Info,
        TodoUrgency.High => Color.Warning,
        TodoUrgency.Urgent => Color.Error,
        _ => Color.Default
    };
}
