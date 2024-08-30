using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities.Items;
internal class Resource : Item
{
    public ResourceType ResourceType { get; set; }
    public Resource(int id, string name, string description, int quantity, ResourceType resourceType)
        : base(id, name, description, quantity)
    {
        ResourceType = resourceType;
    }
}
