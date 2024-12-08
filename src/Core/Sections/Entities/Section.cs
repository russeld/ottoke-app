using Buna.SharedKernel;
using Core.Labels.Entities;
using Core.Todos.Entities;
using Core.Users.Entities;

namespace Core.Sections.Entities;

public class Section : IAggregateRoot
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int Order { get; set; }

    public int LabelId { get; set; }

    public Label Folder { get; set; }

    public List<Todo> Todos { get; set; } = [];

    public string ApplicationUserId { get; set; } = string.Empty;

    public ApplicationUser ApplicationUser { get; set; }
}
