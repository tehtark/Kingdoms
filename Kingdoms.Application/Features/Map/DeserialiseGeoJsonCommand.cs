using GeoJSON.Net.Feature;
using MediatR;
using Newtonsoft.Json;

namespace Kingdoms.Application.Features.Map;

public class DeserialiseGeoJsonCommand : IRequest<FeatureCollection?>;

internal class DeserialiseGeoJsonCommandHandler : IRequestHandler<DeserialiseGeoJsonCommand, FeatureCollection?>
{
    public async Task<FeatureCollection?> Handle(DeserialiseGeoJsonCommand request, CancellationToken cancellationToken)
    {
        var json = await File.ReadAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + @"Map\toureia.geojson");
        return JsonConvert.DeserializeObject<FeatureCollection>(json);
    }
}