namespace Kingdoms.Server.Domain.Entities.Items;

public class Weapon : Item
{
    public Weapon(int id) : base(id)
    {
    }

    public void Attack(Player player)
    {
        Console.WriteLine("Attacking with weapon");
    }
}