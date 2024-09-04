using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Server.Domain.Entities;

public class Player
{
    [Key]
    public Guid PlayerId { get; set; }

    public string Username { get; set; }
    public int Level { get; set; } = 1;
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    public Player(Guid playerId, string username)
    {
        PlayerId = playerId;
        Username = username;
    }
}