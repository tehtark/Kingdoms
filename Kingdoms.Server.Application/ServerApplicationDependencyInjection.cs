using Kingdoms.Server.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Server.Application
{
    public static class ServerApplicationDependencyInjection
    {
        public static IServiceCollection AddServerApplication(this IServiceCollection services)
        {
            services.AddServerInfrastructure();
            return services;
        }
    }
}