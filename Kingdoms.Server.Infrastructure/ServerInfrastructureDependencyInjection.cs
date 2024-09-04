using Kingdoms.Server.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Server.Infrastructure;

public static class ServerInfrastructureDependencyInjection
{
    public static IServiceCollection AddServerInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();

        return services;
    }
}