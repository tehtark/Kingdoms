using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities.Buildings;
internal class ProductionBuilding : Building
{
    public ResourceType ResourceType { get; set; }
    public int ProductionRate { get; set; } = 10;
    public ProductionBuilding(int id, string name, ResourceType resourceType) : base(id, name)
    {
        ResourceType = resourceType;
    }
}
