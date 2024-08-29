using Kingdoms.Server.Domain.Entities.Player;

namespace Kingdoms.Server.Domain.Entities.Items;

public class Weapon : Item
{
    public void Attack(Player.Player player)
    {
        Console.WriteLine("Attacking with weapon");
    }
}