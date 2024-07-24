using Microsoft.Extensions.DependencyInjection;

namespace WrapAround.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
        });

        return services;
    }
}
