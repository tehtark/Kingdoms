using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Kingdoms.Application.Features.Player.Queries;

public record GetPlayerIdFromAuthenticationStateQuery(AuthenticationState? AuthenticationState) : IRequest<string?>;

internal class GetPlayerIdFromAuthenticationStateQueryHandler : IRequestHandler<GetPlayerIdFromAuthenticationStateQuery, string?>
{
    public Task<string?> Handle(GetPlayerIdFromAuthenticationStateQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.AuthenticationState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}