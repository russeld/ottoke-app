using Core.Labels.Entities;
using Core.Todos.Enums;

namespace Core.Todos.Models
{
    public class CreateTodoInputModel
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsImportant { get; set; }

        public TodoUrgency Urgency { get; set; } = TodoUrgency.Low;

        public Label Label { get; set; }
    }
}
