using Kingdoms.Application.Features.Player.Commands;
using Kingdoms.Application.Features.Player.Queries;
using Kingdoms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;

namespace Kingdoms.Application.Services;

public class PlayerService(IMediator mediator)
{
    public async Task Create(string playerId, string username)
    {
        await mediator.Send(new CreatePlayerCommand(playerId, username));
    }

    public async Task<string?> GetPlayerIdAsync(AuthenticationState authenticationState)
    {
        return await mediator.Send(new GetPlayerIdQuery(authenticationState));
    }

    public async Task<Player?> GetPlayerAsync(string playerId)
    {
        return await mediator.Send(new GetPlayerQuery(playerId));
    }
}