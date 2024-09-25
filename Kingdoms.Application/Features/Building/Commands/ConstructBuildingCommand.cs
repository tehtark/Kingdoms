using Kingdoms.Domain.Enums;
using MediatR;

namespace Kingdoms.Application.Features.Building.Commands;

public record ConstructBuildingCommand(Guid HoldingId, BuildingType Type) : IRequest<Domain.Entities.Building>;

internal class ConstructBuildingCommandHandler : IRequestHandler<ConstructBuildingCommand, Domain.Entities.Building>
{
    public Task<Domain.Entities.Building> Handle(ConstructBuildingCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Domain.Entities.Building(new Guid(), request.HoldingId, request.Type));
    }
}