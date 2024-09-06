using Kingdoms.Server.Application.Common.Test.Commands;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Kingdoms.Server.Application;

public class TestService : BackgroundService
{
    private readonly ISender _sender;

    public TestService(ISender sender)
    {
        _sender = sender;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _sender.Send(new TestCommand());
    }
}