using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ApplicationSettings.Helpers;
public static class OptionsLocator
{
    public static TOptions GetApplicationOptions<TOptions>(this IServiceCollection serviceCollection)
        where TOptions : class, IApplicationOptions, new()
        => serviceCollection.BuildServiceProvider().GetApplicationOptions<TOptions>();

    public static TOptions GetApplicationOptions<TOptions>(this IServiceProvider serviceProvider)
        where TOptions : class, IApplicationOptions, new()
    {
        var options = serviceProvider.GetService<IOptions<TOptions>>()?.Value;

        if (options != null) return options;
        throw new InvalidOperationException(
            $"No configuration found for {typeof(TOptions).Name}. "
            + $"Please ensure that services.ConfigureOptions<ConfigureApplicationOptions<{typeof(TOptions).Name}>>() "
            + $"is called in {Assembly.GetCallingAssembly().GetName().Name}.");
    }
}
