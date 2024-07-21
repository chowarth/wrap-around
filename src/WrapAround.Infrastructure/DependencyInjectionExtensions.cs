using Microsoft.Extensions.DependencyInjection;

namespace WrapAround.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // TODO:
        // Move DbContext into infrastructure project
        // Move Identity into infrastructure project
        // See https://github.com/neozhu/CleanArchitectureWithBlazorServer/blob/main/src/Infrastructure/DependencyInjection.cs
        return services;
    }
}
