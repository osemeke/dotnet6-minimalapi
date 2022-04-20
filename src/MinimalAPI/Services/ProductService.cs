using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Entities;

namespace MinimalAPI.Services
{
    public class ProductService
    {
        private InMemoryDbContext _context;

        public ProductService(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }


    }
}
