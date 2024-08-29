namespace Kingdoms.Server.Domain.Entities.Player;

public class Player
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public Inventory Inventory { get; set; }

    public Player(int id, string username, Inventory inventory)
    {
        Id = id;
        Username = username;
        Inventory = inventory;
    }
}