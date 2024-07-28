using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WrapAround.Application.Common.Persistence;
using WrapAround.Infrastructure.Common.Persistence;
using WrapAround.Infrastructure.Services;
using WrapAround.Infrastructure.Sessions.Persistence;

namespace WrapAround.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter()
            .AddPersistence()
            .AddIdentity();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISessionRepository, SessionRepository>();

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

        services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

        return services;
    }
}
