using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Trace;
using WrapAround.Infrastructure.Common.Persistence;

namespace WrapAround.Migrations;

public class Worker : BackgroundService
{
    public const string ActivityName = "MigrationService";
    private static readonly ActivitySource _activitySource = new (ActivityName);

    private readonly IServiceProvider _serviceProvider;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public Worker(
        IServiceProvider serviceProvider,
        IHostApplicationLifetime applicationLifetime)
    {
        _serviceProvider = serviceProvider;
        _applicationLifetime = applicationLifetime;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var activity = _activitySource.StartActivity("Migrating database", ActivityKind.Client);

        try
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await dbContext.Database.MigrateAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            activity?.RecordException(ex);
            throw;
        }

        _applicationLifetime.StopApplication();
    }
}
