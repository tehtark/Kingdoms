using Kingdoms.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kingdoms.Application.Features.Holding.Queries;

public record GetEnemyHoldingsQuery(string PlayerId) : IRequest<List<Domain.Entities.Holding>>;

internal class GetEnemyHoldingsQueryHandler : IRequestHandler<GetEnemyHoldingsQuery, List<Domain.Entities.Holding>>
{
    public async Task<List<Domain.Entities.Holding>> Handle(GetEnemyHoldingsQuery request, CancellationToken cancellationToken)
    {
        DatabaseContext databaseContext = new();
        return await databaseContext.Holdings.Where(h => h.PlayerId != request.PlayerId).ToListAsync();
    }
}