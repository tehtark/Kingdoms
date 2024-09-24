using MediatR;
using NetTopologySuite.Features;
using NetTopologySuite.IO;
using Newtonsoft.Json;

namespace Kingdoms.Application.Features.Map;

public class DeserialiseGeoJsonCommand : IRequest<FeatureCollection?>;

internal class DeserialiseGeoJsonCommandHandler : IRequestHandler<DeserialiseGeoJsonCommand, FeatureCollection?>
{
    public async Task<FeatureCollection?> Handle(DeserialiseGeoJsonCommand request, CancellationToken cancellationToken)
    {
        var json = await File.ReadAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + @"Map\toureia.geojson");
        var reader = new GeoJsonReader();
        return reader.Read<FeatureCollection>(json);

        return JsonConvert.DeserializeObject<FeatureCollection>(json);
    }
}