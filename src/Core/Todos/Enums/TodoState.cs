using System.ComponentModel;

namespace Core.Todos.Enums;

[Flags]
public enum TodoState
{
    [Description("Active")]
    Active         = 1 << 0,
    [Description("Completed")]
    Completed   = 1 << 1,
    [Description("Won't Do")]
    WontDo      = 1 << 2,
    [Description("Deleted")]
    Delete      = 1 << 3,
    [Description("Important")]
    Important   = 1 << 4
}
