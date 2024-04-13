using ApplicationSettings.Helpers;
using ApplicationSettings.Options;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class Configure
{
    /// <summary>
    ///     Configure <see cref="Infrastructure" /> layer.
    ///     <para>
    ///         Required options
    ///         <list type="bullet">
    ///             <item>
    ///                 <see cref="SqlServerOptions" />
    ///             </item>
    ///         </list>
    ///     </para>
    /// </summary>
    /// <param name="services"></param>
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>((serviceProvider, builder) =>
        {
            var sqlServerOptions = serviceProvider.GetApplicationOptions<SqlServerOptions>();
            builder.UseSqlServer(
                sqlServerOptions.ConnectionString,
                options =>
                {
                    options.EnableRetryOnFailure(sqlServerOptions.MaxRetryCount);
                    options.CommandTimeout(sqlServerOptions.CommandTimeout);
                });
            builder.EnableSensitiveDataLogging(sqlServerOptions.EnableSensitiveDataLogging);
            builder.EnableDetailedErrors(sqlServerOptions.EnableDetailedErrors);
        });
    }
}
