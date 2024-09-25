using Kingdoms.Application.Features.Map.Commands;
using Kingdoms.Application.Features.Map.Queries;
using MediatR;
using NetTopologySuite.Features;

namespace Kingdoms.Application.Services;

public class MapService(IMediator mediator)
{
    public async Task<FeatureCollection> GetFeatures()
    {
        return await mediator.Send(new DeserialiseGeoJsonCommand());
    }

    public async Task<List<string>> GetStates()
    {
        return await mediator.Send(new GetMapStatesQuery(await GetFeatures()));
    }
}