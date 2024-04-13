using ApplicationSettings.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationSettings;
public static class Configure
{
    /// <summary>
    ///     Adds user-secrets.
    ///     appsettings.json will not be added.
    /// </summary>
    /// <param name="config"></param>
    public static void AddApplicationSettings(this IConfigurationBuilder config)
        => config.AddUserSecrets<AssemblyReference>();

    /// <summary>
    ///     Configures and registers application options.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <typeparam name="TOptions">Type of options to configure and register.</typeparam>
    public static void ConfigureApplicationOptions<TOptions>(this IServiceCollection serviceCollection)
        where TOptions : class, IApplicationOptions, new()
    {
        serviceCollection.ConfigureOptions<ConfigureApplicationOptions<TOptions>>();
    }
}
