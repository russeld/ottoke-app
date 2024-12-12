using Buna.SharedKernel;
using Core.Habits.Enums;

namespace Core.Habits.Entities;

public class Habit : IAggregateRoot
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsArchived { get; set; } = false;

    public HabitFrequency Frequency { get; set; } = HabitFrequency.Daily;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string ApplicationUserId { get; set; } = string.Empty;
}
