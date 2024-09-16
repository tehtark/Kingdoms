using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Game.Commands;

public record UpdateBuildingsConstructionCommand : IRequest;

internal class UpdateBuildingsConstructionCommandHandler(DatabaseContext databaseContext) : IRequestHandler<UpdateBuildingsConstructionCommand>
{
    public async Task Handle(UpdateBuildingsConstructionCommand request, CancellationToken cancellationToken)
    {
        if (databaseContext.Buildings.Count() != 0) {
            // Update building construction
            var buildingsUnderConstruction = databaseContext.Buildings.Where(b => !b.IsConstructed && b.ConstructionStartTime.HasValue).ToList();

            foreach (var building in buildingsUnderConstruction) {
                if (building.ConstructionStartTime == null) return;

                var elapsedTime = DateTime.Now - building.ConstructionStartTime.Value;
                if (elapsedTime.TotalSeconds >= building.ConstructionDuration) {
                    building.IsConstructed = true;
                }
            }
            await databaseContext.SaveChangesAsync();
        }
    }
}