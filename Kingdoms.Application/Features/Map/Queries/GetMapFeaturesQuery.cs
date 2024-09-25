using Kingdoms.Application.Services;
using MediatR;
using NetTopologySuite.Features;

namespace Kingdoms.Application.Features.Map.Queries;

public class GetMapFeaturesQuery : IRequest<FeatureCollection?>;

internal class GetMapFeaturesQueryHandler(MapService mapService) : IRequestHandler<GetMapFeaturesQuery, FeatureCollection?>
{
    public async Task<FeatureCollection?> Handle(GetMapFeaturesQuery request, CancellationToken cancellationToken)
    {
        return await mapService.GetFeatures();
    }
}