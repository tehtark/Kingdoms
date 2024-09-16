using Kingdoms.Application.Features.Game.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Kingdoms.Application.Services;

public class GameTickService(IServiceProvider serviceProvider)
{
    private int _tick;

    public int Tick {
        get => _tick;
        private set {
            _tick = value;
            OnTickUpdated?.Invoke();
        }
    }

    private readonly int _tickRate = 10;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public event Func<Task> OnTickUpdated;

    public async Task Initialise()
    {
        await Start();
    }

    private async Task Start()
    {
        while (true) {
            await Task.Delay(TimeSpan.FromSeconds(_tickRate));
            using (var scope = _serviceProvider.CreateScope()) {
                var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
                await mediator.Send(new UpdateBuildingsConstructionCommand());
            }

            Tick += 1;

            if (OnTickUpdated != null) {
                await Task.WhenAll(OnTickUpdated.GetInvocationList().Cast<Func<Task>>().Select(del => del()));
            }
        }
    }
}