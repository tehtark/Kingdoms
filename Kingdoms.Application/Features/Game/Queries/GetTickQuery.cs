using Kingdoms.Application.Services;
using MediatR;

namespace Kingdoms.Application.Features.Game.Queries;

public record GetTickQuery : IRequest<int>;

internal class GetTickQueryHandler(GameTickService gameTickService) : IRequestHandler<GetTickQuery, int>
{
    public Task<int> Handle(GetTickQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(gameTickService.Tick);
    }
}