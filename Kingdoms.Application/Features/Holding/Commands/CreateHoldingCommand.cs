using Kingdoms.Domain.Enums;
using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Commands;

public record CreateHoldingCommand(string PlayerId, HoldingType HoldingType) : IRequest<Domain.Entities.Holding?>;

internal class CreateHoldingCommandHandler(DatabaseContext databaseContext) : IRequestHandler<CreateHoldingCommand, Domain.Entities.Holding?>
{
    public async Task<Domain.Entities.Holding?> Handle(CreateHoldingCommand request, CancellationToken cancellationToken)
    {
        var holding = new Domain.Entities.Holding(new(), request.PlayerId, request.HoldingType);
        await databaseContext.Holdings.AddAsync(holding);
        await databaseContext.SaveChangesAsync();
        return holding;
    }
}