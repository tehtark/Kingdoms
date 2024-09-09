using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Player.Commands;
public record CreatePlayerCommand(string Id, string Username) : IRequest<Domain.Entities.Player>;

internal class CreatePlayerCommandHandler(DatabaseContext databaseContext) : IRequestHandler<CreatePlayerCommand, Domain.Entities.Player>
{
    public async Task<Domain.Entities.Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Domain.Entities.Player(request.Id, request.Username);
        databaseContext.Players.Add(player);
        await databaseContext.SaveChangesAsync(cancellationToken);
        return player;
    }
}