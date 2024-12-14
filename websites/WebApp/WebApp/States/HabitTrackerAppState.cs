
using Core.Habits.Entities;

namespace WebApp.States;

public class HabitTrackerAppState : IHabitTrackerAppState
{
    private List<Habit> _habits = [];

    public List<Habit> Habits 
    { 
        get => _habits;
    }

    public event Action? OnChange;

    public void UpdateState()
    {
        OnChange?.Invoke();
    }

    public void SetHabits(List<Habit> habits)
    {
        _habits = habits;
        UpdateState();
    }

    public void AddHabit(Habit habit)
    {
        _habits.Add(habit);
        UpdateState();
    }

    public void UpdateHabit(Habit habit)
    {
        var index = _habits.FindIndex(h => h.Id == habit.Id);
        _habits[index] = habit;
        UpdateState();
    }

    public void RemoveHabit(Habit habit)
    {
        _habits.Remove(habit);
        UpdateState();
    }
}
