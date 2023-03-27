using SolidProductApi.Models;

namespace SolidProductApi.Services.ProductServices
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> AddProductAsync(Product product);
    }
}
