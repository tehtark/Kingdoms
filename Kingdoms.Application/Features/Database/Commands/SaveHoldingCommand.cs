using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Database.Commands;

public record SaveHoldingCommand(Domain.Entities.Holding Holding) : IRequest;

internal class SaveHoldingCommandHandler(DatabaseContext databaseContext) : IRequestHandler<SaveHoldingCommand>
{
    public async Task Handle(SaveHoldingCommand request, CancellationToken cancellationToken)
    {
        databaseContext.Holdings.Add(request.Holding);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }
}