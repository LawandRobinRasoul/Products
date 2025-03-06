using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace ProductsClientAppBlazor.Models
{
    public class ProductPost
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonPropertyName("colourIds")]
        public List<int> ColourIds  { get; set; } = new List<int>();
    }
}
