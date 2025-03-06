using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace ProductsApi.Apimodels.Request
{
    public record ProductPost
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; init; }

        [JsonPropertyName("colourIds")]
        public ImmutableList<int> ColourIds  { get; init; }
    }
}
