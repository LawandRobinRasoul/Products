using System.Collections.Immutable;

namespace ProductsApi.Apimodels.Response
{
    public record ProductSlim
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public DateTimeOffset CreatedAt { get; init; }
    }
}
