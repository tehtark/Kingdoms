using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Queries;

public record GetHoldingsByPlayerIdQuery(string PlayerId) : IRequest<List<Domain.Entities.Holding>>;

internal class GetHoldingsByPlayerIdQueryHandler(DatabaseContext databaseContext) : IRequestHandler<GetHoldingsByPlayerIdQuery, List<Domain.Entities.Holding>>
{
    public Task<List<Domain.Entities.Holding>> Handle(GetHoldingsByPlayerIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(databaseContext.Holdings.Where(h => h.PlayerId == request.PlayerId).ToList());
    }
}