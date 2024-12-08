using Humanizer;

namespace Core.Extensions;

public static class DateExtensions
{
    public static string Humanized(this DateTime date)
    {
        return date.Humanize(utcDate: true);
    }

    public static string DueDateToString(this DateTime? date)
    {
        if (date == null)
        {
            return "";
        }

        if (date!.Value.Date == DateTime.Today)
        {
            return "Today";
        }
        if (date!.Value.Date == DateTime.Today.AddDays(1))
        {
            return "Tomorrow";
        }
        if (date!.Value.Date == DateTime.Today.AddDays(-1))
        {
            return "Yesterday";
        }

        if (date!.Value.Date == DateTime.Today.AddDays(7))
        {
            return "Next week";
        }

        return $"{date!.Value.ToString("MMM dd")}";
    }
}
