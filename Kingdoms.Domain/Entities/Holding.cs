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

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Holding(Guid id, string playerId, HoldingType type, double latitude, double longitude)
    {
        Id = id;
        PlayerId = playerId;
        Type = type;
        Buildings = new List<Building>();
        Resources = new Resources { Id = new(), HoldingId = id };
        Latitude = latitude;
        Longitude = longitude;
    }
}