using Kingdoms.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();
    }
}