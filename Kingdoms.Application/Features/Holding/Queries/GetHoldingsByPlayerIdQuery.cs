using Kingdoms.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kingdoms.Application.Features.Holding.Queries;

public record GetHoldingsByPlayerIdQuery(string PlayerId) : IRequest<List<Domain.Entities.Holding>>;

internal class GetHoldingsByPlayerIdQueryHandler(DatabaseContext databaseContext) : IRequestHandler<GetHoldingsByPlayerIdQuery, List<Domain.Entities.Holding>>
{
    public async Task<List<Domain.Entities.Holding>> Handle(GetHoldingsByPlayerIdQuery request, CancellationToken cancellationToken)
    {
        return await databaseContext.Holdings
            .Where(h => h.PlayerId == request.PlayerId)
            .Include(b => b.Buildings)
            .Include(r => r.Resources)
            .ToListAsync(cancellationToken);
    }
}