using Microsoft.EntityFrameworkCore;
using SolidProductApi.Models;

namespace SolidProductApi.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly DbContext _context;

        public ProductService(DbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
