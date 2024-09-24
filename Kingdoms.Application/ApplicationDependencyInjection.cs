using Kingdoms.Application.Services;
using Kingdoms.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Application;

public static class ApplicationDependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        });

        AddServices(services);
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<HoldingConstructionService>();
        services.AddSingleton<GameTickService>();
        services.AddHostedService<GameService>();
    }
}