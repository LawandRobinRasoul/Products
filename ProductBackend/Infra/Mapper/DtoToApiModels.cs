using ProductsApi.Apimodels.Response;
using ProductsApi.Infra.Models;
using System.Collections.Immutable;

namespace ProductsApi.Infra.Mapper
{
    public static class DtoToApiModels
    {

        public static ProductDetails ToProductDetails(this ProductDto dto)
        {

            return new ProductDetails
            {
                Id = dto.Id,
                Name = dto.Name,
                ProductType = new Apimodels.Response.ProductType
                {
                    Id = dto.ProductType.Id,
                    Name = dto.ProductType.Name
                },
                Colours = dto.ProductColours.Select(pc => new Apimodels.Response.Colour
                {
                    Id = pc.Colour.Id,
                    Name = pc.Colour.Name!
                }).ToImmutableList()
            };
        }

        public static ImmutableList<ProductSlim> ToProductsSlim(this ImmutableList<ProductDto> dto)
        {
            return dto.Select(p => new ProductSlim
            {
                Id = p.Id,
                Name = p.Name,
                CreatedAt = p.CreatedAt
            }).ToImmutableList();
        }

    }
}
