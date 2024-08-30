using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities.Buildings;
internal class Quarry : Building
{
    public ResourceType ResourceType { get { return ResourceType.Stone; } }
    public int ProductionRate { get; set; } = 10;
    public Quarry(int id, string name) : base(id, name)
    {
    }

    public override void Upgrade()
    {
        base.Upgrade();

        ProductionRate += 5;
    }
}
