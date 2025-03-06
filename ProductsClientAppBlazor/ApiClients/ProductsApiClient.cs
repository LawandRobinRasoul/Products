using ProductsClientAppBlazor.Models;
using System.Collections.Immutable;

namespace ProductsClientAppBlazor.ApiClients
{
    public class ProductsApiClient
    {
        private readonly HttpClient httpClient;
        public ProductsApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Product> CreateProductAsync(ProductPost product)
        {
            var response = await httpClient.PostAsJsonAsync("products", product);
            response.EnsureSuccessStatusCode();
            var createdProduct = await response.Content.ReadFromJsonAsync<Product>();
            return createdProduct!;
        }

        public async Task<ProductDetails> GetProductDetailsAsync(int id)
        {
            var productDetails = await httpClient.GetFromJsonAsync<ProductDetails>($"products/{id}");
            return productDetails!;
        }

        public async Task<ImmutableList<ProductSlim>> GetProductsAsync()
        {
            var products = await httpClient.GetFromJsonAsync<List<ProductSlim>>("products");
            return products!.ToImmutableList();
        }
    }
}
