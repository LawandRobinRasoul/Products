using ProductsApi.Apimodels.Request;
using ProductsApi.Apimodels.Response;
using System.Collections.Immutable;

namespace ProductsApi
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(ProductPost product);
        Task<ProductDetails> GetProductDetailsAsync(int id);

        ImmutableList<ProductSlim> GetProductsAsync();

    }
}
