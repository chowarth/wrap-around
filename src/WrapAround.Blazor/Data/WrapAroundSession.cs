using Heron.MudCalendar;

namespace WrapAround.Blazor.Data;

public class WrapAroundSession : CalendarItem
{
    public Guid Id { get; set; }
    public double Cost { get; init; }
    public TimeSpan Duration { get; init; }
}