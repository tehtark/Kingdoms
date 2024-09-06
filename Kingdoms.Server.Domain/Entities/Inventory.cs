using System.ComponentModel.DataAnnotations.Schema;

namespace Kingdoms.Server.Domain.Entities;

[NotMapped]
public class Inventory : List<Item>
{
    public int InventoryId { get; set; }
    public int PlayerId { get; set; }
}