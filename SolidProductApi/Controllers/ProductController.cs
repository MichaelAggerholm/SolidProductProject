using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidProductApi.Data;
using SolidProductApi.Models;
using SolidProductApi.Services.ProductServices;

namespace SolidProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            // Henter en liste af produkter fra ProductService asynkront og gemmer dem i variablen 'products'
            var products = await _productService.GetProductsAsync();

            // Opretter et nyt ServiceResponse-objekt med typen 'List<Product>' og gemmer 'products' i dets Data-felt
            var response = new ServiceResponse<List<Product>>
            {
                Data = products
            };

            // Returnerer en HTTP OK-statuskode sammen med det oprettede ServiceResponse-objekt
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Product>>> AddProduct(Product product)
        {
            // Tilføjer et nyt produkt til ProductService asynkront
            await _productService.AddProductAsync(product);

            // Opretter et nyt ServiceResponse-objekt med typen 'Product' og gemmer 'product' i dets Data-felt
            var response = new ServiceResponse<Product>
            {
                Data = product
            };

            // Returnerer en HTTP OK-statuskode sammen med det oprettede ServiceResponse-objekt
            return Ok(response);
        }
    }
}
