using Kingdoms.Domain.Enums;
using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Commands;

public record CreateHoldingCommand(string PlayerId, HoldingType HoldingType, double Latitude, double Longitude) : IRequest<Domain.Entities.Holding?>;

internal class CreateHoldingCommandHandler : IRequestHandler<CreateHoldingCommand, Domain.Entities.Holding?>
{
    public async Task<Domain.Entities.Holding?> Handle(CreateHoldingCommand request, CancellationToken cancellationToken)
    {
        using var databaseContext = new DatabaseContext();

        var holding = new Domain.Entities.Holding(new(), request.PlayerId, request.HoldingType, request.Latitude, request.Longitude);
        await databaseContext.Holdings.AddAsync(holding);
        await databaseContext.SaveChangesAsync();
        return holding;
    }
}