using Kingdoms.Domain.Enums;
using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Building.Commands;

public record ConstructBuildingCommand(Guid HoldingId, BuildingType Type) : IRequest;

internal class ConstructBuildingCommandHandler : IRequestHandler<ConstructBuildingCommand>
{
    public async Task Handle(ConstructBuildingCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Building building = new Domain.Entities.Building(new(), request.HoldingId, request.Type);

        using DatabaseContext databaseContext = new();
        databaseContext.Buildings.Add(building);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }
}