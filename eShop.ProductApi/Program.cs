using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using MySqlConnector;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var rawConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var dbHost = Environment.GetEnvironmentVariable("MYSQL_HOST");
var dbPort = Environment.GetEnvironmentVariable("MYSQL_PORT");
var dbName = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("MYSQL_USER");
var dbPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");

var finalConnectionString = rawConnectionString?
    .Replace("{MYSQL_DATABASE}", dbName)
    .Replace("{MYSQL_USER}", dbUser)
    .Replace("{MYSQL_PASSWORD}", dbPassword)
    .Replace("{MYSQL_HOST}", dbHost)
    .Replace("{MYSQL_PORT}", dbPort);


// Exemplo usando Entity Framework Core + MySQL (Pomelo)
builder.Services.AddDbContext<DbContext>(options =>
    options.UseMySql(finalConnectionString, ServerVersion.AutoDetect(finalConnectionString)));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

var pass = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "Não encontrei essa senha!";

app.UseHttpsRedirection();

app.MapGet("/", () =>
{

    return $"Eu estou funcionando, e direito! StringConnection: {finalConnectionString}";
});

app.Run();

