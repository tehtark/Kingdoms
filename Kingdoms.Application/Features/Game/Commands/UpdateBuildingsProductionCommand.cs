﻿using Kingdoms.Domain.Enums;
using Kingdoms.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kingdoms.Application.Features.Game.Commands;

public record UpdateBuildingsProductionCommand : IRequest;

internal class UpdateBuildingsProductionCommandHandler : IRequestHandler<UpdateBuildingsProductionCommand>
{
    public async Task Handle(UpdateBuildingsProductionCommand request, CancellationToken cancellationToken)
    {
        using var databaseContext = new DatabaseContext();

        var holdings = await databaseContext.Holdings
            .Include(h => h.Buildings.Where(c => c.IsConstructed == true))
            .Include(r => r.Resources)
            .ToListAsync(cancellationToken);

        foreach (var holding in holdings)
        {
            if (holding.Buildings == null) continue;
            foreach (var building in holding.Buildings)
            {
                switch (building.Type)
                {
                    case BuildingType.Lumberyard:
                        holding.Resources.Wood += building.ProductionRate;
                        break;

                    case BuildingType.Quarry:
                        holding.Resources.Stone += building.ProductionRate;
                        break;

                    case BuildingType.Mine:
                        holding.Resources.Iron += building.ProductionRate;
                        break;
                }
            }
        }

        await databaseContext.SaveChangesAsync();
    }
}