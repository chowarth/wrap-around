using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using WrapAround.Web.Components.Account;

namespace WrapAround.Web;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAuthenticationComponents()
            .AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
            })
            .AddRazorComponents()
            .AddInteractiveServerComponents();

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
