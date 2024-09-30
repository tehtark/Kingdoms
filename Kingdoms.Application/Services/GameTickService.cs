using Kingdoms.Application.Features.Game.Commands;
using MediatR;
using Serilog;

namespace Kingdoms.Application.Services;

public class GameTickService(IMediator mediator)
{
    private int _tick;

    public int Tick
    {
        get => _tick;
        private set
        {
            _tick = value;
            OnTickUpdated?.Invoke();
        }
    }

    private readonly int _tickRate = 15;

    public event Func<Task>? OnTickUpdated;

    public async Task Initialise()
    {
        await Start();
    }

    private async Task Start()
    {
        while (true)
        {
            Log.Debug("GameTickService: Tick!");
            Tick += 1;
            await mediator.Send(new UpdateBuildingsConstructionCommand());
            await mediator.Send(new UpdateBuildingsProductionCommand());

            if (OnTickUpdated != null)
            {
                await Task.WhenAll(OnTickUpdated.GetInvocationList().Cast<Func<Task>>().Select(del => del()));
            }
            await Task.Delay(TimeSpan.FromSeconds(_tickRate));
        }
    }
}