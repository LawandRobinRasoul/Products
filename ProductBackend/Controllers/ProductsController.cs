using Microsoft.AspNetCore.Mvc;
using ProductsApi;
using ProductsApi.Apimodels.Request;
using ProductsApi.Apimodels.Response;
using System.Collections.Immutable;

namespace ProductBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private readonly IProductRepository productRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            this.logger = logger;
            this.productRepository = productRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public IActionResult GetProducts()
        {
            var result = productRepository.GetProductsAsync();

            return Ok(result);
        }

        [HttpPost(Name = "PostProduct")]
        public async Task<IActionResult> PostProduct([FromBodyAttribute] ProductPost productPost)
        {
            var result = await productRepository.CreateProductAsync(productPost);

            return CreatedAtAction(nameof(GetProduct), new { id = result.Id }, result);

        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var result = await productRepository.GetProductDetailsAsync(id);

            return Ok(result);
        }
    }
}
