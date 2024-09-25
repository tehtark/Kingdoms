using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Database.Commands;

public record SaveHoldingCommand(Domain.Entities.Holding Holding) : IRequest;

internal class SaveHoldingCommandHandler : IRequestHandler<SaveHoldingCommand>
{
    public async Task Handle(SaveHoldingCommand request, CancellationToken cancellationToken)
    {
        using DatabaseContext databaseContext = new();
        databaseContext.Holdings.Add(request.Holding);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }
}