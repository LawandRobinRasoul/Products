using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace ProductsClientAppBlazor.Models
{
    public record ProductSlim
    {
        [JsonPropertyName("id")]
        public required int Id { get; init; }

        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [JsonPropertyName("createdAt")]
        public required DateTimeOffset CreatedAt { get; init; }
    }
}
