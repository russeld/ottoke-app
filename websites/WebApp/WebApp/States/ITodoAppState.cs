using Core.Labels.Entities;
using Core.Todos.Entities;

namespace WebApp.States
{
    public interface ITodoAppState
    {
        List<Todo> Todos { get; set; }

        List<Label> Labels { get; set; }

        event Action? OnChange;

        void UpdateState();

        // todos
        void SetTodos(List<Todo> todos);
        void Add(Todo todo);
        void Remove(Todo todo);
        void Update(Todo todo);

        // labels
        void SetLabels(List<Label> labels);
        void Remove(Label label);
        void Update(Label label);
        void Add(Label label);
    }
}