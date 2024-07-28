using Microsoft.Extensions.Hosting;
using WrapAround.Infrastructure.Common.Persistence;

namespace WrapAround.Infrastructure
{
    public static class HostApplicationBuilderExtensions
    {
        public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder, string connectionName)
        {
            builder.AddSqlServerDbContext<ApplicationDbContext>(connectionName);

            return builder;
        }
    }
}