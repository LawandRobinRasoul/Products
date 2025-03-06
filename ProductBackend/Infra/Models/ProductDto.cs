using ProductsApi.Apimodels.Response;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Infra.Models
{
    public record ProductDto
    {

        [Key]
        public int Id { get; init; }

        [Required]
        public required string Name { get; init; }

        [Required]
        public int ProductTypeId { get; init; }

        public  DateTimeOffset CreatedAt { get; init; }


        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        public List<ProductColour> ProductColours { get; set; } = new();

    }

    public record ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }

    public record Colour
    {
        [Key]
        public required int Id { get; init; }

        [Required]
        public required string? Name { get; init; }
    }

    public record ProductColour
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int ColourId { get; set; }
        public Colour Colour { get; set; }
    }
}
