namespace WrapAround.Web.Services;

internal interface IWrapAroundSessionService
{
    Task<IEnumerable<WrapAroundSession>> GetSessions();
}

internal sealed class WrapAroundSessionService : IWrapAroundSessionService
{
    private readonly List<WrapAroundSession> _sessions =
    [
        // Week 1
        new () { Text = "Breakfast Club", Start = DateTime.Today, Duration = TimeSpan.FromMinutes(60), Cost = 3.00},
        new () { Text = "After School Club", Start = DateTime.Today, Duration = TimeSpan.FromMinutes(90), Cost = 5.00 },
        new () { Text = "Breakfast Club", Start = DateTime.Today.AddDays(1), Duration = TimeSpan.FromMinutes(60), Cost = 3.00 },
        new () { Text = "After School Club", Start = DateTime.Today.AddDays(1), Duration = TimeSpan.FromMinutes(90), Cost = 5.00 },
        new () { Text = "Breakfast Club", Start = DateTime.Today.AddDays(3), Duration = TimeSpan.FromMinutes(60), Cost = 3.00 },
        new () { Text = "After School Club", Start = DateTime.Today.AddDays(3), Duration = TimeSpan.FromMinutes(90), Cost = 5.00 },

        // Week 2
        new () { Text = "Breakfast Club", Start = DateTime.Today.AddDays(7), Duration = TimeSpan.FromMinutes(60), Cost = 3.00},
        new () { Text = "After School Club", Start = DateTime.Today.AddDays(7), Duration = TimeSpan.FromMinutes(90), Cost = 5.00 },
        new () { Text = "Breakfast Club", Start = DateTime.Today.AddDays(8), Duration = TimeSpan.FromMinutes(60), Cost = 3.00 },
        new () { Text = "After School Club", Start = DateTime.Today.AddDays(8), Duration = TimeSpan.FromMinutes(90), Cost = 5.00 },
        new () { Text = "Breakfast Club", Start = DateTime.Today.AddDays(10), Duration = TimeSpan.FromMinutes(60), Cost = 3.00 },
        new () { Text = "After School Club", Start = DateTime.Today.AddDays(10), Duration = TimeSpan.FromMinutes(90), Cost = 5.00 }
    ];

    public Task<IEnumerable<WrapAroundSession>> GetSessions()
    {
        return Task.FromResult<IEnumerable<WrapAroundSession>>(_sessions);
    }
}
