using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Kingdoms.Application.Features.Player.Queries;

public record GetPlayerIdQuery(AuthenticationState AuthenticationState) : IRequest<string?>;

internal class GetPlayerIdQueryHandler : IRequestHandler<GetPlayerIdQuery, string?>
{
    public Task<string?> Handle(GetPlayerIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.AuthenticationState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}