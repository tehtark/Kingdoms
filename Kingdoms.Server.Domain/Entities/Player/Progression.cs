namespace Kingdoms.Server.Domain.Entities.Player;

public class Progression
{
    public int Id { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public Progression(int id, int level, int experience)
    {
        Id = id;
        Level = level;
        Experience = experience;
    }
}