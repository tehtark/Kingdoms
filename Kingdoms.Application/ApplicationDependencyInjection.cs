using Kingdoms.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Application;

public static class ApplicationDependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => {
            config.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        });

        services.AddInfrastructure();
    }
}