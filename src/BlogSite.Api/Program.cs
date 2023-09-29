using BlogSite.DataAccess.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = BuildConnectionString();

builder.Services.AddDataAccess(connectionString!);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started with connection string: {connectionString}", connectionString);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();

app.MapControllers();

// TODO: Set environment variable for CORS
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => origin.Equals("https://4998b9d.online-server.cloud") || origin.Equals("http://localhost")) // allow any origin  
    .AllowCredentials());               // allow credentials 

app.Run();

string? BuildConnectionString()
{
    var user = Environment.GetEnvironmentVariable("DB_USER");
    var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
    var host = Environment.GetEnvironmentVariable("DB_HOST");
    var port = Environment.GetEnvironmentVariable("DB_PORT");
    
    return builder.Configuration.GetConnectionString("mysql")?
        .Replace("{{DB_USER}}", user)
        .Replace("{{DB_PASSWORD}}", password)
        .Replace("{{DB_HOST}}", host)
        .Replace("{{DB_PORT}}", port ?? "3306")
        .Replace("{{DB_NAME}}", "db");
}