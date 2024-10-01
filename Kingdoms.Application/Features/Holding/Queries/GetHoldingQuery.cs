using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Queries;

public record GetHoldingQuery(Guid HoldingId) : IRequest<Domain.Entities.Holding?>;

internal class GetHoldingQueryHandler : IRequestHandler<GetHoldingQuery, Domain.Entities.Holding?>
{
    public async Task<Domain.Entities.Holding?> Handle(GetHoldingQuery request, CancellationToken cancellationToken)
    {
        DatabaseContext databaseContext = new();
        return await databaseContext.Holdings.FindAsync(request.HoldingId);
    }
}