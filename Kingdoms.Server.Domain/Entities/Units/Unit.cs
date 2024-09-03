using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities.Units;

internal class Unit
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public UnitType UnitType { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Cost { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; } = 100;
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }

    public Unit(int id, int playerId)
    {
        Id = id;
        PlayerId = playerId;
    }
}