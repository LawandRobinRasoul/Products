using System.Collections.Immutable;

namespace ProductsApi.Apimodels.Response
{
    public record ProductDetails
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public required ProductType ProductType { get; init; }

        public required ImmutableList<Colour> Colours { get; init; }
    }

    public record Colour
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }

    public record ProductType
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
