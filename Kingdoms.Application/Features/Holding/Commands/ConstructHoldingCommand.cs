using Kingdoms.Domain.Enums;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Commands;

public record ConstructHoldingCommand(string PlayerId, HoldingType Type, double Longitude, double Latitude) : IRequest<Domain.Entities.Holding>;

internal class ConstructHoldingCommandHandler : IRequestHandler<ConstructHoldingCommand, Domain.Entities.Holding>
{
    public Task<Domain.Entities.Holding> Handle(ConstructHoldingCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Domain.Entities.Holding(new Guid(), request.PlayerId, request.Type, request.Longitude, request.Latitude));
    }
}