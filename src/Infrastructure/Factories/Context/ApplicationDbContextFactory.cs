using ApplicationSettings;
using ApplicationSettings.Options;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Factories.Context;
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder();
        configuration.AddApplicationSettings();
        var builtConfig = configuration.Build();

        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(builtConfig);
        services.ConfigureApplicationOptions<SqlServerOptions>();
        services.AddInfrastructure();
        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
