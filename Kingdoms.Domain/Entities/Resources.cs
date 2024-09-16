using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Domain.Entities;

public class Resources
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid HoldingId { get; set; }

    public int Wood { get; set; }
    public int Stone { get; set; }
    public int Iron { get; set; }
}