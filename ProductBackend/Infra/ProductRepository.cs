using Microsoft.EntityFrameworkCore;
using ProductsApi.Apimodels.Request;
using ProductsApi.Apimodels.Response;
using ProductsApi.Infra.Db;
using ProductsApi.Infra.Mapper;
using ProductsApi.Infra.Models;
using System.Collections.Immutable;

namespace ProductsApi.Infra
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext productsDbContext;

        public ProductRepository(ProductsDbContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;

        }
        public async Task<Product> CreateProductAsync(ProductPost product)
        {
            try
            {
                var productToCreate = new ProductDto
                {
                    Name = product.Name,
                    ProductTypeId = product.ProductTypeId,
                    ProductColours = product.ColourIds.Select(id => new ProductColour { ColourId = id }).ToList()
                };

                productsDbContext.Add(productToCreate);
                await productsDbContext.SaveChangesAsync();

                return new Product()
                {
                    Colours = product.ColourIds,
                    Name = productToCreate.Name,
                    ProductTypeId = productToCreate.ProductTypeId,
                    Id = productToCreate.Id
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating product", ex);
            }
        }

        public async Task<ProductDetails> GetProductDetailsAsync(int id)
        {
            try
            {
                var product = await productsDbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductColours)
                .ThenInclude(pc => pc.Colour)
                .FirstOrDefaultAsync(p => p.Id == id);

                return product!.ToProductDetails();


            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product details", ex);
            }
        }

        public ImmutableList<ProductSlim> GetProductsAsync()
        {
            try
            {
                var products = productsDbContext.Products.Select(p => p)
                    .ToImmutableList();

                return products!.ToProductsSlim();


            }
            catch (Exception ex)
            {
                throw new Exception("Error getting products", ex);
            }
        }
    }
}
