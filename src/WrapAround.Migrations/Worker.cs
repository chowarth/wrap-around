using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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

            // Why are a multiple (4) connection exceptions thrown before the migrations then run and succeed?
            // Microsoft.EntityFrameworkCore.Infrastructure[10404]
            // A transient exception occurred during execution. The operation will be retried after 7549ms.
            //     Microsoft.Data.SqlClient.SqlException (0x80131904): A connection was successfully established with the server, but then an error occurred during the pre-login handshake. (provider: TCP Provider, error: 0 - An existing connection was forcibly closed by the remote host.)
            //     ---> System.ComponentModel.Win32Exception (10054): An existing connection was forcibly closed by the remote host.

            // Is this because it's trying to run before the database has started?
            // Add the WaitFor dependency in AppHost

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
