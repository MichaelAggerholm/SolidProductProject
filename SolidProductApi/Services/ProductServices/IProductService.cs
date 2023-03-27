using SolidProductApi.Models;

namespace SolidProductApi.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> AddProductAsync(Product product);
    }
}
