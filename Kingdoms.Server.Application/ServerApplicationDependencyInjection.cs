using Kingdoms.Server.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Server.Application
{
    public static class ServerApplicationDependencyInjection
    {
        public static IServiceCollection AddServerApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(typeof(ServerApplicationDependencyInjection).Assembly);
            });

            services.AddHostedService<TestService>();

            services.AddServerInfrastructure();

            return services;
        }
    }
}