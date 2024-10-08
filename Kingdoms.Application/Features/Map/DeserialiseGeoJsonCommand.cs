﻿using MediatR;
using NetTopologySuite.Features;
using NetTopologySuite.IO;

namespace Kingdoms.Application.Features.Map;

public class DeserialiseGeoJsonCommand : IRequest<FeatureCollection?>;

internal class DeserialiseGeoJsonCommandHandler(HttpClient httpClient) : IRequestHandler<DeserialiseGeoJsonCommand, FeatureCollection?>
{
    public async Task<FeatureCollection?> Handle(DeserialiseGeoJsonCommand request, CancellationToken cancellationToken)
    {
        var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/tehtark/Kingdoms/refs/heads/dev/Kingdoms.Infrastructure/Map/toureia.geojson");
        var reader = new GeoJsonReader();
        return reader.Read<FeatureCollection>(json);
    }
}