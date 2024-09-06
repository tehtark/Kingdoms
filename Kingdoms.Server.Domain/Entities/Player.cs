using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Server.Domain.Entities;

public class Player
{
    public int PlayerId { get; set; }
    public string Username { get; set; }
    public int Level { get; set; } = 1;
    public Inventory Inventory { get; set; }
}