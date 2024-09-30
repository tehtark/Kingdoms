using Kingdoms.Application.Features.Database.Commands;
using MediatR;

namespace Kingdoms.Application.Services;

public class DatabaseService(IMediator mediator)
{
    public async Task ResetDatabaseAsync()
    {
        await mediator.Send(new ResetDatabaseCommand());
    }
}