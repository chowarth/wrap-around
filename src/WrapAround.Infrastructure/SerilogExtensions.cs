using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;
using Serilog.Templates;

namespace WrapAround.Infrastructure;

public static class SerilogExtensions
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
    {
        // See: https://nblumhardt.com/2021/06/customize-serilog-text-output/
        var template = new ExpressionTemplate(
            "[{@t:yyyy-MM-dd HH:mm:ss.fff zzz}] " +
            "[{@l:u3}]" +
            "{#if SourceContext is not null} [{Substring(SourceContext, LastIndexOf(SourceContext, '.') + 1)}]{#end}" +
            " {@m}\n{@x}");

        builder.Host.UseSerilog((_, configuration) =>
        {
            configuration
                .WriteTo.Debug(template, LogEventLevel.Information)
                .WriteTo.Console(template, LogEventLevel.Information);
        });

        return builder;
    }
}
