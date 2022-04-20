using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Entities;

namespace MinimalAPI.Services
{
    public class ProductService
    {
        //private InMemoryDbContext _context;

        //public ProductService(InMemoryDbContext context)
        //{
        //    _context = context;
        //}

        private SQLiteDbContext _context;

        public ProductService(SQLiteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.Where(_ => _.Id == id).FirstAsync();
        }

        public async Task<Product> AddProductAsync(Product model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Product> UpdateProduct(Product model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var model = await _context.Products.Where(_ => _.Id == id).FirstAsync();
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

    }
}
