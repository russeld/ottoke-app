using Core.Habits.Entities;

namespace WebApp.States;

public interface IHabitTrackerAppState
{
    event Action? OnChange;

    void UpdateState();

    List<Habit> Habits { get; }

    void SetHabits(List<Habit> habits);

    void AddHabit(Habit habit);

    void UpdateHabit(Habit habit);

    void RemoveHabit(Habit habit);
}
