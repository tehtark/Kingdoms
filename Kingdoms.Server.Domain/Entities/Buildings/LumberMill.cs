using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities.Buildings;
internal class LumberMill : Building
{
    public ResourceType ResourceType { get { return ResourceType.Wood; } }
    public int ProductionRate { get; set; } = 10;

    public LumberMill(int id, string name) : base(id, name)
    {
    }

    public override void Upgrade()
    {
        base.Upgrade();

        ProductionRate += 5;
    }
}
