using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Building.Commands;

public record RemoveBuildingCommand(Guid BuildingId) : IRequest;

internal class RemoveBuildingCommandHandler : IRequestHandler<RemoveBuildingCommand>
{
    public async Task Handle(RemoveBuildingCommand request, CancellationToken cancellationToken)
    {
        using DatabaseContext databaseContext = new();
        databaseContext.Buildings.RemoveRange(databaseContext.Buildings.Where(b => b.Id == request.BuildingId));
        await databaseContext.SaveChangesAsync();
    }
}