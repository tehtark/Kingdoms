using Microsoft.Extensions.Hosting;

namespace Kingdoms.Application.Services;

public class GameService(GameTickService gameTickService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await gameTickService.Initialise();
    }
}