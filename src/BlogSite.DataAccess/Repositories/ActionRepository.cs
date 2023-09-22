using System.Data.SqlClient;
using BlogSite.CrossCutting;
using BlogSite.DataAccess.DbEntities;
using BlogSite.Domain.Contracts;
using BlogSite.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace BlogSite.DataAccess.Repositories;

public class ActionRepository : IActionRepository
{
    private readonly MySqlConnection _connection;
    private readonly ILogger<ActionRepository> _logger;

    public ActionRepository(MySqlConnection connection, ILogger<ActionRepository> logger)
    {
        _connection = connection;
        _logger = logger;
    }
    
    public async Task<Result> LogAction(AppAction action)
    {
        try
        {
            _logger.LogInformation("Logging action: {action}", action.Action);
            var sql = "INSERT INTO access (Id, Action, Data, CreatedAt, CreatedBy) " +
                      "VALUES (@Id, @Action, @Data, @CreatedAt, @CreatedBy)";
            var dbAction = AppActionDbEntity.FromAction(action);
            var result = await _connection.ExecuteAsync(sql, dbAction);
            return (result > 0)
                ? Result.Success()
                : Result.Failure("Failed to log action");
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to log action: {e.Message}");
            return Result.Failure(e.Message);
        }
    }
}