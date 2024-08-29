namespace Kingdoms.Server.Domain.Entities.Player;

public class Player
{
    public int Id { get; set; }
    public string Username { get; set; }
    public Progression Progression { get; set; }
    public Inventory Inventory { get; set; }

    public Player(int id, string username, Progression progression, Inventory inventory)
    {
        Id = id;
        Username = username;
        Progression = progression;
        Inventory = inventory;
    }
}