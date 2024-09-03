using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities;

internal class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public LocationType LocationType { get; set; }
    public TerrainType TerrainType { get; set; }
    public int Difficulty { get; set; }

    public Location(int id, string name, LocationType locationType, TerrainType terrainType, int difficulty = 0)
    {
        Id = id;
        Name = name;
        LocationType = locationType;
        TerrainType = terrainType;
        Difficulty = difficulty;
    }
}