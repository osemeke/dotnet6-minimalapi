using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalAPI.Data;
using MinimalAPI.Entities;
using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container

//sqlite
builder.Services.AddDbContext<DbContext, SQLiteDbContext>();

//in-memory
//builder.Services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("myDb"));

builder.Services.AddScoped<ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Osemeke Minimal API", Version = "v1" });
});

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection(); // force use https. comment to use postman or File > Settings > Off the SSL certificate verification in General Tab

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Osemeke Minimal API");
    options.RoutePrefix = string.Empty; //"swagger/ui"; //string.Empty; // to arrest the root page use string.Empty
                                       // clear browser cache anytime this value is cahange
});

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//app.MapGet("/", () => "Hello World!");

// Get all
app.MapGet("/products", async (ProductService s) =>
{
    return await s.GetProductsAsync();
});

// Get
app.MapGet("/products/{id}", async (int id, ProductService s) =>
{
    return await s.GetProductAsync(id);
});

// Create
app.MapPost("/products", async (Product model, ProductService s) =>
{
    return await s.AddProductAsync(model);
});

// Update
app.MapPut("/products/{id}", async (Product model, ProductService s) =>
{
    return await s.UpdateProduct(model);
});

// Delete
app.MapDelete("/products/{id}", async (int id, ProductService s) =>
{
    return await s.DeleteProductAsync(id);
});

app.Run();
