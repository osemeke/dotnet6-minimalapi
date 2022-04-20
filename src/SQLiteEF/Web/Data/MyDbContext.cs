using Microsoft.EntityFrameworkCore;

namespace Web.Entities
{
    public class MyDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=myapp.db");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "TV",
            });
        }

        public DbSet<Product> Products => Set<Product>();
    }
}

/* PM> Install-Package Microsoft.EntityFrameworkCore
 PM> Install-Package Microsoft.EntityFrameworkCore.Sqlite
 PM> Install-Package Microsoft.EntityFrameworkCore.Tools*/

/* PM> add-migration init
 PM> update-database*/