using Kingdoms.Domain.Enums;
using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Building.Commands;

public record CreateBuildingCommand(Guid HoldingId, BuildingType Type) : IRequest<Domain.Entities.Building>;

internal class CreateBuildingCommandHandler(DatabaseContext databaseContext) : IRequestHandler<CreateBuildingCommand, Domain.Entities.Building>
{
    public async Task<Domain.Entities.Building> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Building building = new(new(), request.HoldingId, request.Type);
        databaseContext.Buildings.Add(building);
        await databaseContext.SaveChangesAsync();
        return building;
    }
}