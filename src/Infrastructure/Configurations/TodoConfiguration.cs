using Core.Todos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasOne(e => e.Label)
           .WithMany(e => e.Todos)
           .HasForeignKey(e => e.LabelId)
           .OnDelete(DeleteBehavior.SetNull);
    }
}
