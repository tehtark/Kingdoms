using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Domain.Entities;

public class Player
{
    [Key]
    public string Id { get; set; }

    public string Username { get; set; }
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 1;
    public int Gold { get; set; } = 0;

    public Player(string id, string username)
    {
        Id = id;
        Username = username;
    }

    public Player(string id, string username, int level, int experience, int gold)
    {
        Id = id;
        Username = username;
        Level = level;
        Experience = experience;
        Gold = gold;
    }
}