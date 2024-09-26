using Kingdoms.Domain.Enums;
using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Commands;

public record ConstructHoldingCommand(string PlayerId, HoldingType Type, double Longitude, double Latitude) : IRequest;

internal class ConstructHoldingCommandHandler : IRequestHandler<ConstructHoldingCommand>
{
    public async Task Handle(ConstructHoldingCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Holding holding = new Domain.Entities.Holding(new(), request.PlayerId, request.Type, request.Longitude, request.Latitude);
        using DatabaseContext databaseContext = new();
        databaseContext.Holdings.Add(holding);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }
}