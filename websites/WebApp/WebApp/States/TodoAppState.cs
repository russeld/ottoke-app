using Core.Labels.Entities;
using Core.Todos.Entities;

namespace WebApp.States;

public class TodoAppState : ITodoAppState
{
    private List<Todo> _todos = [];

    public List<Todo> Todos
    {
        get
        {
            return [.. _todos.OrderByDescending(t => t.DueDate is not null)
             .ThenBy(t => t.DueDate)
             .ThenByDescending(t => t.IsImportant)
             .ThenByDescending(t => t.Urgency)];
        }
        set
        {
            _todos = value;
            UpdateState();
        }
    }

    public List<Label> Labels { get; set; } = [];

    public void SetTodos(List<Todo> todos)
    {
        _todos = todos;
        UpdateState();
    }

    public void Add(Todo todo)
    {
        _todos.Add(todo);
        UpdateState();
    }

    public void Remove(Todo todo)
    {
        _todos.Remove(todo);
        UpdateState();
    }

    public void Update(Todo todo)
    {
        var index = _todos.FindIndex(t => t.Id == todo.Id);
        _todos[index] = todo;
        UpdateState();
    }

    public void UpdateState()
    {
        OnChange?.Invoke();
    }

    public event Action? OnChange;

    public void SetLabels(List<Label> labels)
    {
        Labels = labels;
        UpdateState();
    }

    public void Add(Label label)
    {
        Labels.Add(label);
        UpdateState();
    }

    public void Remove(Label label)
    {
        Labels.Remove(label);
        UpdateState();
    }

    public void Update(Label label)
    {
        var index = Labels.FindIndex(l => l.Id == label.Id);
        Labels[index] = label;
        UpdateState();
    }
}
