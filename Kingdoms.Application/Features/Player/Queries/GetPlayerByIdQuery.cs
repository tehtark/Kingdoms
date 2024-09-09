using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Player.Queries;

public record GetPlayerByIdQuery(string Id) : IRequest<Domain.Entities.Player?>;

internal class GetPlayerByIdQueryHandler(DatabaseContext databaseContext) : IRequestHandler<GetPlayerByIdQuery, Domain.Entities.Player?>
{
    public async Task<Domain.Entities.Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        return await databaseContext.Players.FindAsync(request.Id);
    }
}