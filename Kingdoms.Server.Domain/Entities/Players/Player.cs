namespace Kingdoms.Server.Domain.Entities.Players;

public class Player
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Health { get; set; }
    private int _maxHealth = 100;
    public int Stamina { get; set; }
    private int _maxStamina = 100;
    public int Magicka { get; set; }
    private int _maxMagicka = 100;
    public PlayerInventory PlayerInventory { get; set; }

    public Player(int id, string username, PlayerInventory inventory)
    {
        Id = id;
        Username = username;
        PlayerInventory = inventory;
    }
}