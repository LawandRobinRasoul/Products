using System.Collections.Immutable;

namespace ProductsClientAppBlazor.Models
{
    public record Product
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public required int ProductTypeId { get; init; }

        public required ImmutableList<int> Colours { get; init; }

    }
}
