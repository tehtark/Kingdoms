using Kingdoms.Application.Features.Database.Commands;
using Kingdoms.Application.Features.Holding.Commands;
using Kingdoms.Application.Features.Map;
using Kingdoms.Domain.Entities;
using Kingdoms.Domain.Enums;
using MediatR;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;

namespace Kingdoms.Application.Services;

public class HoldingConstructionService(IMediator mediator)
{
    public async Task Construct(string playerId, HoldingType holdingType)
    {
        FeatureCollection? features = await GetFeatures();
        if (features == null) return;

        IFeature feature = features[1];
        Envelope boundingBox = feature.Geometry.EnvelopeInternal;

        Random random = new();
        Coordinate coordinate;
        do
        {
            double latitude = random.NextDouble() * (boundingBox.MaxY - boundingBox.MinY) + boundingBox.MinY;
            double longitude = random.NextDouble() * (boundingBox.MaxX - boundingBox.MinX) + boundingBox.MinX;
            coordinate = new Coordinate(longitude, latitude);
        } while (!((Polygon)feature.Geometry).Contains(new Point(coordinate)));

        Holding holding = await mediator.Send(new ConstructHoldingCommand(playerId, holdingType, coordinate.X, coordinate.Y));
        await mediator.Send(new SaveHoldingCommand(holding));
    }

    private async Task<FeatureCollection?> GetFeatures()
    {
        return await mediator.Send(new DeserialiseGeoJsonCommand());
    }
}