using Buna.SharedKernel;
using Core.Labels.Entities;
using Core.Sections.Entities;
using Core.Todos.Enums;

namespace Core.Todos.Entities
{
    public class Todo : IAggregateRoot
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public bool IsImportant { get; set; } = false;

        public TodoUrgency Urgency { get; set; } = TodoUrgency.Low;

        public string? Description { get; set; }

        public bool IsDeleted { get; set; }

        public int? LabelId { get; set; }

        public Label? Label { get; set; }

        public int? SectionId { get; set; }

        public Section? Section { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? DateCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;

        public void Complete()
        {
            IsCompleted = true;
            UpdatedAt = DateTime.UtcNow;
            DateCompleted = DateTime.UtcNow;
        }

        public void Uncomplete()
        {
            IsCompleted = false;
            UpdatedAt = DateTime.UtcNow;
            DateCompleted = null;
        }
    }
}
