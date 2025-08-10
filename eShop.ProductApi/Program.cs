using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var rawConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Substitui o placeholder pela senha da variável de ambiente
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var finalConnectionString = rawConnectionString?.Replace("{DB_PASSWORD}", dbPassword);

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



app.UseHttpsRedirection();

app.MapGet("/", () =>
{

    return "null";
});

app.Run();