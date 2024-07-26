using Heron.MudCalendar;

namespace WrapAround.Web.Services;

public class WrapAroundSession : CalendarItem
{
    public double Cost { get; init; }
    public TimeSpan Duration { get; init; }
}
