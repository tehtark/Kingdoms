using Kingdoms.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kingdoms.Application.Features.Holding.Queries;

public record GetPlayerHoldingsQuery(string PlayerId) : IRequest<List<Domain.Entities.Holding>>;

internal class GetPlayerHoldingsQueryHandler : IRequestHandler<GetPlayerHoldingsQuery, List<Domain.Entities.Holding>>
{
    public async Task<List<Domain.Entities.Holding>> Handle(GetPlayerHoldingsQuery request, CancellationToken cancellationToken)
    {
        using var databaseContext = new DatabaseContext();

        return await databaseContext.Holdings
            .Where(h => h.PlayerId == request.PlayerId)
            .Include(b => b.Buildings)
            .Include(r => r.Resources)
            .ToListAsync(cancellationToken);
    }
}