using Microsoft.EntityFrameworkCore;
using SolidProductApi.Models;

namespace SolidProductApi.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext DataContext)
        {
            _context = DataContext;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var serviceResponse = new ServiceResponse<List<Product>>();

            var products = await _context.Products.ToListAsync();
            serviceResponse.Data = products;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Product>> AddProductAsync(Product product)
        {
            var response = new ServiceResponse<Product>();

            product.Id = Guid.NewGuid();

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            response.Data = product;

            return response;
        }
    }
}
