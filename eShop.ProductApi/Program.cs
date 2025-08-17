using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using eShop.ProductApi.Context;
using eShop.ProductApi.Repositories;
using eShop.ProductApi.Services;
using System.Text.Json.Serialization;
using eShop.ProductApi.DTO.Mappings;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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


    
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(finalConnectionString, ServerVersion.AutoDetect(finalConnectionString)));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

