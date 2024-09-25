using MediatR;
using NetTopologySuite.Features;

namespace Kingdoms.Application.Features.Map.Queries;

public record GetMapFeatureFromStateQuery(FeatureCollection Features, string State) : IRequest<IFeature?>;

internal class GetMapFeatureFromStateQueryHandler : IRequestHandler<GetMapFeatureFromStateQuery, IFeature?>
{
    public Task<IFeature?> Handle(GetMapFeatureFromStateQuery request, CancellationToken cancellationToken)
    {
        IFeature? feature = null;

        foreach (var item in request.Features)
        {
            string? state = item.Attributes.GetOptionalValue("State").ToString();
            if (state == request.State)
            {
                feature = item;
                break;
            }
        }
        return Task.FromResult(feature);
    }
}