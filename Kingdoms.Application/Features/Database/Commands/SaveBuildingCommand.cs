using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Database.Commands;
public record SaveBuildingCommand(Domain.Entities.Building Building) : IRequest;

internal class SaveBuildingCommandHandler : IRequestHandler<SaveBuildingCommand>
{
    public async Task Handle(SaveBuildingCommand request, CancellationToken cancellationToken)
    {
        using DatabaseContext databaseContext = new();
        databaseContext.Buildings.Add(request.Building);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }
}