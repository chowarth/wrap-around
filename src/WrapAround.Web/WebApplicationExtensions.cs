using WrapAround.Infrastructure.Common.Persistence;
using WrapAround.Web.Components;

namespace WrapAround.Web;

internal static class WebApplicationExtensions
{
    internal static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.MapDefaultEndpoints();
        app.UseHttpsRedirection()
            .UseStaticFiles()
            .UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();

        return app;
    }
}
