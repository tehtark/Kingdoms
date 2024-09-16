using Kingdoms.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Domain.Entities;

public class Building
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid HoldingId { get; set; }

    [Required]
    public BuildingType Type { get; set; }

    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public bool IsConstructed { get; set; }
    public DateTime? ConstructionStartTime { get; private set; }
    public int ConstructionDuration { get; private set; } = 100;

    public Building(Guid id, Guid holdingId, BuildingType type)
    {
        Id = id;
        HoldingId = holdingId;
        Type = type;
        Name = Type.ToString();
        ConstructionStartTime = DateTime.Now;
    }
}