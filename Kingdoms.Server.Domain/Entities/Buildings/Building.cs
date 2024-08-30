namespace Kingdoms.Server.Domain.Entities.Buildings;
public class Building
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public bool IsConstructed { get; set; }
    public DateTime? ConstructionStartTime { get; set; }
    public TimeSpan ConstructionTime { get; set; }

    public Building(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public virtual void Upgrade()
    {
        Level++;
    }

    public virtual void Construct()
    {
        IsConstructed = true;
    }
}
