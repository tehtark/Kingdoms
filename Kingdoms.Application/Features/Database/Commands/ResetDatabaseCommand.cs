using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Database.Commands;

public record ResetDatabaseCommand : IRequest;

internal class ResetDatabaseCommandHandler : IRequestHandler<ResetDatabaseCommand>
{
    public async Task Handle(ResetDatabaseCommand request, CancellationToken cancellationToken)
    {
        using DatabaseContext databaseContext = new();
        databaseContext.Players.RemoveRange(databaseContext.Players);
        databaseContext.Holdings.RemoveRange(databaseContext.Holdings);
        databaseContext.Buildings.RemoveRange(databaseContext.Buildings);
        databaseContext.Resources.RemoveRange(databaseContext.Resources);
        await databaseContext.SaveChangesAsync();
    }
}