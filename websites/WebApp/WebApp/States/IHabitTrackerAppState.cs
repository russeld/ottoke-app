namespace WebApp.States;

public interface IHabitTrackerAppState
{
    event Action? OnChange;

    void UpdateState();
}
