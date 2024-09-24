namespace Kingdoms.Domain.Entities;

public class Icon
{
    public string Url { get; set; }

    public Icon(string url)
    {
        Url = url;
    }
}