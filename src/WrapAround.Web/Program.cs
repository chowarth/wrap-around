using WrapAround.Application;
using WrapAround.Infrastructure;
using WrapAround.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog()
    .AddServiceDefaults()
    .AddInfrastructure("wraparound-db");

// Add services to the container.
builder.Services
    .AddInfrastructure()
    .AddApplication()
    .AddPresentation();

builder.Build()
    .ConfigureWebApplication()
    .Run();
