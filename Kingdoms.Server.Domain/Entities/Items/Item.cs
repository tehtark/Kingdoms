namespace Kingdoms.Server.Domain.Entities.Items;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }

    public Item(int id, string name, string description, int quantity)
    {
        Id = id;
        Name = name;
        Description = description;
        Quantity = quantity;
    }
}