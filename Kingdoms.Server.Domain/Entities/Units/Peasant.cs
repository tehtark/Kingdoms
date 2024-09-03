using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities.Units;

internal class Peasant : Unit
{
    public Peasant(int id, int playerId, int level = 1) : base(id, playerId)
    {
        Name = "Peasant";
        UnitType = UnitType.Melee;
        Level = level;
        Health = MaxHealth;
        Attack = 1;
        Defense = 1;
        Speed = 1;
    }
}