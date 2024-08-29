using WrapAround.Infrastructure.Common.Persistence;
using WrapAround.Migrations;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivityName));

builder.AddSqlServerDbContext<ApplicationDbContext>("wraparound-db");

var host = builder.Build();
host.Run();
