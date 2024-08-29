var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);
var database = builder.AddSqlServer("wraparound-sqlserver", password: sqlPassword, port: 1234)
    .WithDataVolume("wraparound-sql-data")
    .AddDatabase("wraparound-db");

builder.AddProject<Projects.WrapAround_Web>("wraparound-web")
    .WithReference(database);

builder.AddProject<Projects.WrapAround_Migrations>("wraparound-migrations")
    .WithReference(database);

builder.Build().Run();
