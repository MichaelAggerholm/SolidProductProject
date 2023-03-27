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

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var serviceResponse = new ServiceResponse<List<Product>>();

            try
            {
                var products = await _context.Products.ToListAsync();
                serviceResponse.Data = products;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Product>> AddProductAsync(Product product)
        {
            var response = new ServiceResponse<Product>();

            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                response.Data = product;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
