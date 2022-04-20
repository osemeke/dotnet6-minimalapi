using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;

namespace MinimalAPI.Data
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) 
            : base(options) 
        {
            Seed();
        }

        public DbSet<Product> Products { get; set; }

        private void Seed()
        {
            Products.Add(new Product()
            {
                Id = 1,
                Name = "TV",
                Photo = "random/tv.png",
                CategoryId = 1,
            });
            Products.Add(new Product()
            {
                Id = 2,
                Name = "Air Conditioner",
                Photo = "random/ac.png",
                CategoryId = 1,
            });
            this.SaveChanges();
        }

    }
}
