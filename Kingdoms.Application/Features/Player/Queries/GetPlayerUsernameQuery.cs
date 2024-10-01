using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Player.Queries;

public record GetPlayerUsernameQuery(string PlayerId) : IRequest<string?>;

internal class GetPlayerUsernameQueryHandler : IRequestHandler<GetPlayerUsernameQuery, string?>
{
    public async Task<string?> Handle(GetPlayerUsernameQuery request, CancellationToken cancellationToken)
    {
        DatabaseContext databaseContext = new();

        return (await databaseContext.Players.FindAsync(request.PlayerId))?.Username;
    }
}