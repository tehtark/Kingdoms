using MediatR;
using NetTopologySuite.Features;

namespace Kingdoms.Application.Features.Map.Queries;

public record GetMapStatesQuery(FeatureCollection Features) : IRequest<List<string>>;

internal class GetMapStatesQueryHandler : IRequestHandler<GetMapStatesQuery, List<string>>
{
    public async Task<List<string>> Handle(GetMapStatesQuery request, CancellationToken cancellationToken)
    {
        List<string> states = new();
        foreach (var feature in request.Features)
        {
            string? state = feature.Attributes.GetOptionalValue("State").ToString();
            states.Add(state);
        }

        return states;
    }
}