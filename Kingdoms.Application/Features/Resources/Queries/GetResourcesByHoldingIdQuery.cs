using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Resources.Queries;

public record GetResourcesByHoldingIdQuery(Guid HoldingId) : IRequest<Domain.Entities.Resources?>;

internal class GetResourcesByHoldingIdQueryHandler(DatabaseContext databaseContext) : IRequestHandler<GetResourcesByHoldingIdQuery, Domain.Entities.Resources?>
{
    public Task<Domain.Entities.Resources?> Handle(GetResourcesByHoldingIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(databaseContext.Resources.FirstOrDefault(r => r.HoldingId == request.HoldingId));
    }
}