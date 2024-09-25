using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Database.Commands;
public record SaveBuildingCommand(Domain.Entities.Building Building) : IRequest;

internal class SaveBuildingCommandHandler(DatabaseContext databaseContext) : IRequestHandler<SaveBuildingCommand>
{
    public async Task Handle(SaveBuildingCommand request, CancellationToken cancellationToken)
    {
        databaseContext.Buildings.Add(request.Building);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }
}