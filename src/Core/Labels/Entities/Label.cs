using Buna.SharedKernel;
using Core.Sections.Entities;
using Core.Todos.Entities;

namespace Core.Labels.Entities;

public class Label : IAggregateRoot
{
    public int Id { get; set; }

    public string Slug { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string ApplicationUserId { get; set; } = string.Empty;

    public DateOnly CreatedAt { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public List<Todo> Todos { get; set; } = [];

    public List<Section> Sections { get; set; } = [];
}
