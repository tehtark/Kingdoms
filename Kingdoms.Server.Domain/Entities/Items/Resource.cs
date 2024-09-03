using Kingdoms.Server.Domain.Enums;

namespace Kingdoms.Server.Domain.Entities.Items;

internal class Resource : Item
{
    public ResourceType ResourceType { get; set; }

    public Resource(int id, ResourceType resourceType)
        : base(id)
    {
        ResourceType = resourceType;
    }
}