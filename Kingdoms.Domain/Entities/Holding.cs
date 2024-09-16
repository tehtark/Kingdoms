using Kingdoms.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Domain.Entities;

public class Holding
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string PlayerId { get; set; }

    [Required]
    public HoldingType Type { get; set; }

    public ICollection<Building>? Buildings { get; set; }

    public Resources? Resources { get; set; }

    public Holding(Guid id, string playerId, HoldingType type)
    {
        Id = id;
        PlayerId = playerId;
        Type = type;
        Buildings = new List<Building>();
        Resources = new Resources { Id = new(), HoldingId = id };
    }
}