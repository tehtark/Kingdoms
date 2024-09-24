using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Queries;
public record GetAllHoldingsQuery : IRequest<List<Domain.Entities.Holding>>;

internal class GetAllHoldingsQueryHandler(DatabaseContext databaseContext) : IRequestHandler<GetAllHoldingsQuery, List<Domain.Entities.Holding>>
{
    public Task<List<Domain.Entities.Holding>> Handle(GetAllHoldingsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(databaseContext.Holdings.ToList());
    }
}