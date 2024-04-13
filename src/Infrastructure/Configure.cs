using Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class Configure
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
    }
}
