using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Player.Queries;

public record GetPlayerQuery(string Id) : IRequest<Domain.Entities.Player?>;

internal class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, Domain.Entities.Player?>
{
    public async Task<Domain.Entities.Player?> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        using var databaseContext = new DatabaseContext();

        return await databaseContext.Players.FindAsync(request.Id, cancellationToken);
    }
}