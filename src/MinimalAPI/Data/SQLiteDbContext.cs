using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;

namespace MinimalAPI.Data
{
    public class SQLiteDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=myapp.db");

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Small TV",
                Photo = "random/small-tv.png",
                CategoryId = 1,
            });
        }
    }
}

/* PM> Install-Package Microsoft.EntityFrameworkCore
 PM> Install-Package Microsoft.EntityFrameworkCore.Sqlite
 PM> Install-Package Microsoft.EntityFrameworkCore.Tools*/ // <-- for migrations!

/* PM> add-migration init
 PM> update-database*/