using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Server.Domain.Entities;

public class Inventory
{
    [Key]
    public Guid InventoryId { get; set; }

    [Required]
    public Guid PlayerId { get; set; }

    public Player Player { get; set; }

    public List<InventoryItem> Items { get; set; } = [];
}