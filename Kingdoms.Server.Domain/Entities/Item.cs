namespace Kingdoms.Server.Domain.Entities;

public class Item
{
    public int ItemId { get; set; }

    public int PlayerId { get; set; }

    public string? Name { get; set; }

    public int Qunatity { get; set; }
}