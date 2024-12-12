
namespace WebApp.States;

public class HabitTrackerAppState : IHabitTrackerAppState
{
    public event Action? OnChange;

    private void NotifyOnChange() => OnChange?.Invoke();

    public void UpdateState()
    {
        NotifyOnChange();
    }
}
