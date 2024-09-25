using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Queries;
public record GetAllHoldingsQuery : IRequest<List<Domain.Entities.Holding>>;

internal class GetAllHoldingsQueryHandler : IRequestHandler<GetAllHoldingsQuery, List<Domain.Entities.Holding>>
{
    public Task<List<Domain.Entities.Holding>> Handle(GetAllHoldingsQuery request, CancellationToken cancellationToken)
    {
        using var databaseContext = new DatabaseContext();

        return Task.FromResult(databaseContext.Holdings.ToList());
    }
}