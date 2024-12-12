using Core.Habits.Enums;

namespace Core.Habits.Models;

public class CreateHabitInputModel
{
    public string Name { get; set; } = string.Empty;

    public bool IsArchived { get; set; } = false;

    public HabitFrequency Frequency { get; set; } = HabitFrequency.Daily;

    public string? Description { get; set; }
}
