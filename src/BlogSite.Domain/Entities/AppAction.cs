namespace BlogSite.Domain.Entities;

public class AppAction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Action { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
}