﻿using Kingdoms.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kingdoms.Application.Features.Building.Queries;

public record GetBuildingsByHoldingIdQuery(Guid HoldingId) : IRequest<List<Domain.Entities.Building>>;

internal class GetBuildingsByHoldingIdQueryHandler : IRequestHandler<GetBuildingsByHoldingIdQuery, List<Domain.Entities.Building>>
{
    public async Task<List<Domain.Entities.Building>> Handle(GetBuildingsByHoldingIdQuery request, CancellationToken cancellationToken)
    {
        using var databaseContext = new DatabaseContext();

        return await databaseContext.Buildings
            .Where(h => h.HoldingId == request.HoldingId)
            .ToListAsync();
    }
}