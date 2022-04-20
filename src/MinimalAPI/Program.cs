using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalAPI.Data;
using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db";
//builder.Services.AddSqlite<SQLiteDbContext>(connectionString);

builder.Services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("myDb"));

builder.Services.AddScoped<ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Osemeke Minimal API", Version = "v1" });
});
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

//app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async (ProductService s) =>
{
    return await s.GetProductsAsync();
});

app.Run();
