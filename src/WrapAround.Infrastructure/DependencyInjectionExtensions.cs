using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WrapAround.Application.Common.Abstractions;
using WrapAround.Application.Common.Abstractions.Persistence;
using WrapAround.Infrastructure.Persistence;
using WrapAround.Infrastructure.Services;

namespace WrapAround.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter()
            .AddIdentity();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies();

        services.AddIdentityCore<User>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddSignInManager()
        .AddDefaultTokenProviders();

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());
        services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

        return services;
    }
}
