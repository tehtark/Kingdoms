using Kingdoms.Application.Services;
using MediatR;

namespace Kingdoms.Application.Features.Game.Queries;

public record GetTickQuery : IRequest<int>;

internal class GetTickQueryHandler(GameTickService gameTickService) : IRequestHandler<GetTickQuery, int>
{
    public async Task<int> Handle(GetTickQuery request, CancellationToken cancellationToken)
    {
        return gameTickService.Tick;
    }
}