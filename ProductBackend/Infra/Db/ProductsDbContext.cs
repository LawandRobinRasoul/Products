using Microsoft.EntityFrameworkCore;
using ProductsApi.Apimodels.Response;
using ProductsApi.Infra.Models;
using Colour = ProductsApi.Infra.Models.Colour;
using ProductType = ProductsApi.Infra.Models.ProductType;

namespace ProductsApi.Infra.Db
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options) { }

        public DbSet<ProductDto> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<ProductColour> ProductColours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDto>()
                .HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId);

            modelBuilder.Entity<ProductDto>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ProductColour>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductColours)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductColour>()
                .HasOne(pc => pc.Colour)
                .WithMany()
                .HasForeignKey(pc => pc.ColourId);


            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Sofa" },
                new ProductType { Id = 2, Name = "Table" }
            );

            modelBuilder.Entity<Colour>().HasData(
                new Colour { Id = 1, Name = "Blue" },
                new Colour { Id = 2, Name = "Ruby" },
                new Colour { Id = 3, Name = "Green" },
                new Colour { Id = 4, Name = "Pink" },
                new Colour { Id = 5, Name = "Yellow" },
                new Colour { Id = 6, Name = "Black" }

            );

            modelBuilder.Entity<ProductDto>().HasData(
                new ProductDto { Id = 1, Name = "LANDSKRONA", ProductTypeId = 1 },
                new ProductDto { Id = 2, Name = "MALMÖ", ProductTypeId = 1 },
                new ProductDto { Id = 3, Name = "STOCKHOLM", ProductTypeId = 2 }

            );

            modelBuilder.Entity<ProductColour>().HasData(
                new ProductColour { Id = 1, ProductId = 1, ColourId = 1 },
                new ProductColour { Id = 2, ProductId = 1, ColourId = 2 },
                new ProductColour { Id = 3, ProductId = 2, ColourId = 5 },
                new ProductColour { Id = 4, ProductId = 3, ColourId = 6 }

            );
        }
    }
}