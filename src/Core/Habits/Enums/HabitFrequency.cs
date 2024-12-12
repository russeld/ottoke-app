using System.ComponentModel;

namespace Core.Habits.Enums;

public enum HabitFrequency
{
    [Description("Daily")]
    Daily = 1,
    [Description("Weekly")]
    Weekly,
    [Description("Monthly")]
    Monthly,
    [Description("Custom")]
    Custom,
    [Description("Event")]
    Event
}
