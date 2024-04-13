using ApplicationSettings.Contracts.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace ApplicationSettings.Common.Options;
public class ConfigureApplicationOptions<TOptions> : IConfigureOptions<TOptions>, IPostConfigureOptions<TOptions>
    where TOptions : class, IApplicationOptions, new()
{
    private readonly IConfiguration _configuration;

    public ConfigureApplicationOptions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(TOptions options) => _configuration.GetSection(typeof(TOptions).Name).Bind(options);

    public void PostConfigure(string? name, TOptions options)
    {
        try
        {
            Validator.ValidateObject(options, new(options), true);
        }
        catch (Exception e)
        {
            throw new(
                $"\nCheck the following properties of section {typeof(TOptions).Name}, section in user secrets or appsettings.json:\n{e.Message}");
        }
    }
}
