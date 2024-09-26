using Kingdoms.Application.Features.Building.Commands;
using Kingdoms.Domain.Entities;
using Kingdoms.Domain.Enums;
using MediatR;

namespace Kingdoms.Application.Services;

public class BuildingService(IMediator mediator)
{
    public async Task Construct(Guid holdingId, BuildingType type)
    {
        await mediator.Send(new ConstructBuildingCommand(holdingId, type));
    }

    public async Task Demolish(Building building)
    {
        throw new NotImplementedException();
    }

    public async Task Upgrade()
    {
        throw new NotImplementedException();
    }
}