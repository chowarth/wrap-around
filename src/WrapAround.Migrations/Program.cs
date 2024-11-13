using Microsoft.EntityFrameworkCore.Diagnostics;
using WrapAround.Infrastructure.Common.Persistence;
using WrapAround.Migrations;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivityName));

builder.AddSqlServerDbContext<ApplicationDbContext>("wraparound-db", configureDbContextOptions: options =>
{
    // Ignore the pending model changes warning so that it doesn't throw and will apply migrations.
    // https://github.com/dotnet/efcore/issues/34431#issuecomment-2413845935
    options.ConfigureWarnings(warnings =>
    {
        warnings.Log(RelationalEventId.PendingModelChangesWarning);
    });
});

var host = builder.Build();
host.Run();
