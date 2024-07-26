using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using WrapAround.Web.Components.Account;
using WrapAround.Web.Services;

namespace WrapAround.Web;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAuthenticationComponents()
            .AddMudServices(config =>
            {
                config.PopoverOptions.ThrowOnDuplicateProvider = false;
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
            })
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        services.AddSingleton<IWrapAroundSessionService, WrapAroundSessionService>();

        return services;
    }

    private static IServiceCollection AddAuthenticationComponents(this IServiceCollection services)
    {
        services.AddCascadingAuthenticationState()
            .AddScoped<IdentityUserAccessor>()
            .AddScoped<IdentityRedirectManager>()
            .AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        return services;
    }
}
