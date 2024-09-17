using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Game.Commands;

public record UpdateBuildingsConstructionCommand : IRequest;

internal class UpdateBuildingsConstructionCommandHandler(DatabaseContext databaseContext) : IRequestHandler<UpdateBuildingsConstructionCommand>
{
    public async Task Handle(UpdateBuildingsConstructionCommand request, CancellationToken cancellationToken)
    {
        var buildingsUnderConstruction = databaseContext.Buildings
            .Where(b => !b.IsConstructed && b.ConstructionStartTime.HasValue)
            .ToList();

        foreach (var building in buildingsUnderConstruction) {
            if (building.ConstructionStartTime == null)
                continue;

            var elapsedTime = DateTime.Now - building.ConstructionStartTime.Value;
            if (elapsedTime.TotalSeconds >= building.ConstructionDuration) {
                building.IsConstructed = true;
            }
        }

        if (buildingsUnderConstruction.Any()) {
            await databaseContext.SaveChangesAsync();
        }
    }
}