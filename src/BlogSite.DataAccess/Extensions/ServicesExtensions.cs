using BlogSite.DataAccess.Repositories;
using BlogSite.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace BlogSite.DataAccess.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddTransient(x =>
            new MySqlConnection(connectionString));
        services.AddScoped<IActionRepository, ActionRepository>();

        return services;
    }
}