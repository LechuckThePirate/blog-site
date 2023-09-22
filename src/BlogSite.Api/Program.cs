using BlogSite.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("mysql")?
    .Replace("{{DB_USER}}", Environment.GetEnvironmentVariable("DB_USER"))
    .Replace("{{DB_PASSWORD}}", Environment.GetEnvironmentVariable("DB_PASSWORD"))
    .Replace("{{DB_HOST}}", Environment.GetEnvironmentVariable("DB_HOST"))
    .Replace("{{DB_PORT}}", Environment.GetEnvironmentVariable("DB_PORT"))
    .Replace("{{DB_NAME}}", "db");

builder.Services.AddDataAccess(connectionString!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// TODO: Set environment variable for CORS
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => origin.Equals("http://4998b9d.online-server.cloud") || origin.Equals("http://localhost")) // allow any origin  
    .AllowCredentials());               // allow credentials 

app.Run();