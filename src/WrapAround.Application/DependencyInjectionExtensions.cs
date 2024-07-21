using Microsoft.Extensions.DependencyInjection;

namespace WrapAround.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
