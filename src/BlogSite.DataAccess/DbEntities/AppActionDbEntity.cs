using BlogSite.Domain.Entities;

namespace BlogSite.DataAccess.DbEntities;

public class AppActionDbEntity
{
    public string Id { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    
    public static AppActionDbEntity FromAction(AppAction action)
    {
        return new AppActionDbEntity
        {
            Id = action.Id.ToString(),
            Action = action.Action,
            Data = action.Data,
            CreatedAt = action.CreatedAt,
            CreatedBy = action.CreatedBy
        };
    }
    
    public static AppAction ToAction(AppActionDbEntity action)
    {
        return new AppAction
        {
            Id = Guid.Parse(action.Id),
            Action = action.Action,
            Data = action.Data,
            CreatedAt = action.CreatedAt,
            CreatedBy = action.CreatedBy
        };
    }
}
