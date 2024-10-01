using Kingdoms.Application.Features.Holding.Commands;
using Kingdoms.Application.Features.Holding.Queries;
using Kingdoms.Application.Features.Map.Queries;
using Kingdoms.Domain.Entities;
using Kingdoms.Domain.Enums;
using MediatR;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;

namespace Kingdoms.Application.Services;

public class HoldingService(IMediator mediator)
{
    public async Task Construct(string playerId, HoldingType holdingType, string state)
    {
        FeatureCollection? features = await mediator.Send(new GetMapFeaturesQuery());
        if (features == null) return;
        IFeature? feature = await mediator.Send(new GetMapFeatureFromStateQuery(features, state));
        if (feature == null) return;
        Envelope boundingBox = feature.Geometry.EnvelopeInternal;

        Random random = new();
        Coordinate coordinate;
        do
        {
            double latitude = random.NextDouble() * (boundingBox.MaxY - boundingBox.MinY) + boundingBox.MinY;
            double longitude = random.NextDouble() * (boundingBox.MaxX - boundingBox.MinX) + boundingBox.MinX;
            coordinate = new Coordinate(longitude, latitude);
        } while (!((Polygon)feature.Geometry).Contains(new Point(coordinate)));

        await mediator.Send(new ConstructHoldingCommand(playerId, holdingType, coordinate.X, coordinate.Y));
    }

    public async Task<Holding?> GetHoldingAsync(Guid holdingId)
    {
        return await mediator.Send(new GetHoldingQuery(holdingId));
    }

    public async Task<List<Holding>> GetAllHoldingsAsync()
    {
        return await mediator.Send(new GetAllHoldingsQuery());
    }

    public async Task<List<Holding>> GetPlayerHoldings(string playerId)
    {
        return await mediator.Send(new GetPlayerHoldingsQuery(playerId));
    }

    public async Task<List<Holding>> GetEnemyHoldingsAsync(string playerId)
    {
        return await mediator.Send(new GetEnemyHoldingsQuery(playerId));
    }
}