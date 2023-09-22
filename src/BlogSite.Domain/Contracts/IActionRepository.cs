using BlogSite.CrossCutting;
using BlogSite.Domain.Entities;

namespace BlogSite.Domain.Contracts;

public interface IActionRepository
{
    Task<Result> LogAction(AppAction action);
}