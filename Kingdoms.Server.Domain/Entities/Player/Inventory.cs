using Kingdoms.Server.Domain.Entities.Items;

namespace Kingdoms.Server.Domain.Entities.Player;

public class Inventory : List<Item>
{
    public int Id { get; set; }
    public int Gold { get; private set; }

    public Inventory(int id, int gold)
    {
        Id = id;
        Gold = gold;
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }

    public void RemoveGold(int amount)
    {
        Gold -= amount;
    }
}