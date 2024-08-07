﻿var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);
var database = builder.AddSqlServer("wraparound-sqlserver", password: sqlPassword)
    .WithDataVolume("wraparound-sql-data")
    .AddDatabase("wraparound-db");

builder.AddProject<Projects.WrapAround_Web>("wraparound-web")
    .WithReference(database);

builder.Build().Run();
