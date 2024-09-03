using Kingdoms.Client.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Client.Application;

public static class ClientApplicationDependencyInjection
{
    public static IServiceCollection AddClientApplication(this IServiceCollection services)
    {
        services.AddSingleton<GameHubService>();

        return services;
    }
}