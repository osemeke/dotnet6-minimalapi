using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;

namespace MinimalAPI.Data
{
    public class SQLiteDbContext : DbContext
    {
        SQLiteDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    Id = 1,
            //    Name = "TV",
            //    Photo = "random/tv.png",
            //    CategoryId = 1,
            //});
        //}

        //public DbSet<Product> Products => Set<Product>();

        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=app.db;Cache=Shared");
    }
}
